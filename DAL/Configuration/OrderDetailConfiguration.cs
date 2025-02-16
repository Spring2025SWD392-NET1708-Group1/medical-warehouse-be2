using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(od => od.Id);

            builder.Property(od => od.Quantity)
                .IsRequired();

            builder.Property(od => od.Price)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(od => od.Item)
                .WithMany()
                .HasForeignKey(od => od.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed Data
            builder.HasData(
                new OrderDetail { Id = 1, OrderId = 1, ItemId = 1, Quantity = 2, Price = 10.00m },
                new OrderDetail { Id = 2, OrderId = 1, ItemId = 2, Quantity = 5, Price = 50.00m }
            );
        }
    }
}
