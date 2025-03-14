using Common.Enums;
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

            builder.Property(i => i.ImportPricePerUnit)
                .HasColumnType("decimal(18,2)");

            builder.Property(i => i.ExportPricePerUnit)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(i => i.ItemCategory)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.ItemCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.User)
                .WithMany(u => u.Items)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed Data
            builder.HasData(
                new Item
                {
                    Id = Guid.Parse("80c0ac22-9f4d-478e-8fe1-f01b4e6727b0"),
                    Name = "Paracetamol",
                    Description = "Pain reliever",
                    ItemCategoryId = Guid.Parse("aed8c311-739c-4264-83a1-8a5e8854c182"),
                    ImportPricePerUnit = 5.00m,
                    ExportPricePerUnit = 5.50m,
                    UnitType = ItemType.Tablet,
                    UserId = Guid.Parse("d8f0b849-d1a2-45d5-8a23-47772060c8f4"), // Supplier
                    IsForSale = true
                },
                new Item
                {
                    Id = Guid.Parse("1bfe3b07-5419-4718-bed9-0439016c7f78"),
                    Name = "Surgical Gloves",
                    Description = "Disposable gloves",
                    ItemCategoryId = Guid.Parse("b7c51ee8-f942-4492-98b7-877b5777cd21"),
                    ImportPricePerUnit = 10.00m,
                    ExportPricePerUnit = 10.50m,
                    UnitType = ItemType.Pack,
                    UserId = Guid.Parse("d8f0b849-d1a2-45d5-8a23-47772060c8f4"), // Supplier
                    IsForSale = true
                },
                new Item
                {
                    Id = Guid.Parse("3d2a1e6d-b173-4db6-a2b4-1cb8bdfb94c9"),
                    Name = "Antibiotic Ointment",
                    Description = "Topical antibiotic treatment",
                    ItemCategoryId = Guid.Parse("c3e3f7f8-8b32-4a3b-9f6a-45ef9d42a4e1"),
                    ImportPricePerUnit = 12.50m,
                    ExportPricePerUnit = 13.50m,
                    UnitType = ItemType.Box,
                    UserId = Guid.Parse("d8f0b849-d1a2-45d5-8a23-47772060c8f4"), // Supplier
                    IsForSale = true
                }
            );
        }
    }
}
