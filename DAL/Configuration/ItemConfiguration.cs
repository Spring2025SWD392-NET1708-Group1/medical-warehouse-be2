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
          .HasForeignKey(i => i.ItemCategoryId)
          .OnDelete(DeleteBehavior.Restrict);

      builder.HasOne(i => i.Storage)
          .WithMany(s => s.Items)
          .HasForeignKey(i => i.StorageId)
          .OnDelete(DeleteBehavior.Restrict);

      // Seed Data
      builder.HasData(
          new Item
          {
            Id = Guid.Parse("80c0ac22-9f4d-478e-8fe1-f01b4e6727b0"),
            Name = "Paracetamol",
            Description = "Pain reliever",
            ItemCategoryId = Guid.Parse("aed8c311-739c-4264-83a1-8a5e8854c182"),
            StorageId = 1,
            Quantity = 100,
            Price = 5.00m,
            ExpiryDate = new DateTime(2026, 12, 31)
          },
          new Item
          {
            Id = Guid.Parse("1bfe3b07-5419-4718-bed9-0439016c7f78"),
            Name = "Surgical Gloves",
            Description = "Disposable gloves",
            ItemCategoryId = Guid.Parse("b7c51ee8-f942-4492-98b7-877b5777cd21"),
            StorageId = 2,
            Quantity = 200,
            Price = 10.00m,
            ExpiryDate = new DateTime(2027, 06, 15)
          },
          new Item
          {
            Id = Guid.Parse("3d2a1e6d-b173-4db6-a2b4-1cb8bdfb94c9"),
            Name = "Antibiotic Ointment",
            Description = "Topical antibiotic treatment",
            ItemCategoryId = Guid.Parse("c3e3f7f8-8b32-4a3b-9f6a-45ef9d42a4e1"),
            StorageId = 3,
            Quantity = 50,
            Price = 12.50m,
            ExpiryDate = new DateTime(2025, 11, 20)
          },
          new Item
          {
            Id = Guid.Parse("4e3a2c5d-9f1b-4d7b-8e6c-b5f2a3d98e4a"),
            Name = "Medicines Item1",
            Description = "Medicines Item1 Description",
            ItemCategoryId = Guid.Parse("aed8c311-739c-4264-83a1-8a5e8854c182"),
            StorageId = 1,
            Quantity = 10,
            Price = 11.50m,
            ExpiryDate = new DateTime(2025, 11, 20)
          },
          new Item
          {
            Id = Guid.Parse("5d2b1a9c-8e7f-6c4d-3b0e-f2a7e4d98b1c"),
            Name = "Medicines Item2",
            Description = "Medicines Item2 Description",
            ItemCategoryId = Guid.Parse("aed8c311-739c-4264-83a1-8a5e8854c182"),
            StorageId = 2,
            Quantity = 20,
            Price = 12.50m,
            ExpiryDate = new DateTime(2025, 12, 20)
          },
          new Item
          {
            Id = Guid.Parse("6e4c2a3d-5b1f-8d7b-9c0e-f2a7e4d98b1c"),
            Name = "Medicines Item3",
            Description = "Medicines Item3 Description",
            ItemCategoryId = Guid.Parse("aed8c311-739c-4264-83a1-8a5e8854c182"),
            StorageId = 3,
            Quantity = 30,
            Price = 13.50m,
            ExpiryDate = new DateTime(2025, 12, 23)
          },
          new Item
          {
            Id = Guid.Parse("7f5b3a1c-2e4d-9c8d-6b0f-a7e4d98b1c2a"),
            Name = "Medicines Item4",
            Description = "Medicines Item4",
            ItemCategoryId = Guid.Parse("aed8c311-739c-4264-83a1-8a5e8854c182"),
            StorageId = 4,
            Quantity = 4,
            Price = 14.50m,
            ExpiryDate = new DateTime(2025, 11, 24)
          },
          new Item
          {
            Id = Guid.Parse("8d6c3b2a-1e4f-9c7b-5d0f-a7e4d98b1c2a"),
            Name = "Medicines Item5",
            Description = "Medicines Item5",
            ItemCategoryId = Guid.Parse("c3e3f7f8-8b32-4a3b-9f6a-45ef9d42a4e1"),
            StorageId = 1,
            Quantity = 50,
            Price = 15.50m,
            ExpiryDate = new DateTime(2025, 11, 25)
          }
      );
    }
  }
}
