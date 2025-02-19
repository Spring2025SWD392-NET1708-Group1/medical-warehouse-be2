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
                new OrderDetail
                {
                    Id = Guid.Parse("5f1f6327-d2a7-46be-9b07-d5f6d5873501"),
                    OrderId = Guid.Parse("d9b4f38f-e9d4-4d2c-a479-746c16a6c697"),
                    ItemId = Guid.Parse("80c0ac22-9f4d-478e-8fe1-f01b4e6727b0"),
                    Quantity = 2,
                    Price = 10.00m
                },
                new OrderDetail
                {
                    Id = Guid.Parse("b8f9e273-3838-4657-9c9b-1e56b4a09d6e"),
                    OrderId = Guid.Parse("d9b4f38f-e9d4-4d2c-a479-746c16a6c697"),
                    ItemId = Guid.Parse("1bfe3b07-5419-4718-bed9-0439016c7f78"),
                    Quantity = 5,
                    Price = 50.00m
                }
            );

        }
    }
}
