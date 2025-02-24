using Common.Enums;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.OrderDate)
                .IsRequired();

            builder.Property(o => o.Status)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed Data
            builder.HasData(
                new Order
                {
                    Id = Guid.Parse("d9b4f38f-e9d4-4d2c-a479-746c16a6c697"),
                    UserId = Guid.Parse("d8f0b849-d1a2-45d5-8a23-47772060c8fc"),
                    OrderDate = DateTime.UtcNow,
                    Status = OrderStatus.Pending
                }
            );

        }
    }
}
