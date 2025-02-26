using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
  public class StorageCategoryConfiguration : IEntityTypeConfiguration<StorageCategory>
  {
    public void Configure(EntityTypeBuilder<StorageCategory> builder)
    {
      builder.HasKey(sc => sc.Id);

      builder.Property(sc => sc.Name)
          .IsRequired()
          .HasMaxLength(100);

      // Seed Data
      builder.HasData(
          new StorageCategory { Id = 1, Name = "Dry Storage" },
          new StorageCategory { Id = 2, Name = "Cold Storage" }
      );
    }
  }
}

