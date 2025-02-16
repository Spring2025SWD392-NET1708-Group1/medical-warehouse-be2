using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(i => i.Description)
                .HasMaxLength(255);

            builder.Property(i => i.Price)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(i => i.ItemCategory)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed Data
            builder.HasData(
                new Item { Id = 1, Name = "Paracetamol", Description = "Pain reliever", CategoryId = 1, Quantity = 100, Price = 5.00m, ExpiryDate = new DateTime(2026, 12, 31) },
                new Item { Id = 2, Name = "Surgical Gloves", Description = "Disposable gloves", CategoryId = 2, Quantity = 200, Price = 10.00m, ExpiryDate = new DateTime(2027, 06, 15) }
            );
        }
    }
}
