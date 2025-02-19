using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<ItemCategory>
    {
        public void Configure(EntityTypeBuilder<ItemCategory> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Seed Data
            builder.HasData(
                new ItemCategory { Id = Guid.Parse("aed8c311-739c-4264-83a1-8a5e8854c182"), Name = "Medicine" },
                new ItemCategory { Id = Guid.Parse("b7c51ee8-f942-4492-98b7-877b5777cd21"), Name = "Surgical Equipment" }
            );
        }
    }
}
