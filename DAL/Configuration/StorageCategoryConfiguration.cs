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

            builder.HasMany<Storage>()
                .WithOne(s => s.StorageCategory)
                .HasForeignKey(s => s.Id)
                .OnDelete(DeleteBehavior.Restrict);
                

            // Seed Data
            builder.HasData(
                new StorageCategory { Id = 1, Name = "Dry Storage" },
                new StorageCategory { Id = 2, Name = "Cold Storage" }
            );
        }
    }
}

