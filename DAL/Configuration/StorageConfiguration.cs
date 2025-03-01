using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class StorageConfiguration : IEntityTypeConfiguration<Storage>
    {
        public void Configure(EntityTypeBuilder<Storage> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(2);

            builder.Property(s => s.IsActive)
                .IsRequired();

            builder.HasOne<StorageCategory>()
                .WithMany()
                .HasForeignKey(s => s.StorageCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed Data
            builder.HasData(
                new Storage { Id = 1, Name = "A1", StorageCategoryId = 1, IsActive = true },
                new Storage { Id = 2, Name = "A2", StorageCategoryId = 1, IsActive = true },
                new Storage { Id = 3, Name = "B1", StorageCategoryId = 2, IsActive = true },
                new Storage { Id = 4, Name = "B2", StorageCategoryId = 2, IsActive = false }
            );
        }
    }
}
