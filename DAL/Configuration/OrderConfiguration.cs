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
                new Order { Id = 1, UserId = 1, OrderDate = DateTime.UtcNow, Status = "Pending" }
            );
        }
    }
}
