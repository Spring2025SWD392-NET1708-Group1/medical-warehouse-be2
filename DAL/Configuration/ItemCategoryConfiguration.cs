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
          new ItemCategory { Id = Guid.Parse("b7c51ee8-f942-4492-98b7-877b5777cd21"), Name = "Surgical Equipment" },
          new ItemCategory { Id = Guid.Parse("c3e3f7f8-8b32-4a3b-9f6a-45ef9d42a4e1"), Name = "First Aid Supplies" },
          new ItemCategory { Id = Guid.Parse("e9f2a4a3-6372-4c96-b7e4-5c90b3a5c14d"), Name = "Medical Devices" },
          new ItemCategory { Id = Guid.Parse("f1b2a3c4-5d6e-7890-1234-56789abcdef0"), Name = "Protective Equipment" },
          new ItemCategory { Id = Guid.Parse("fa4b9a62-d6e3-4c1a-a5b6-7e8f9102b345"), Name = "Vaccines" }
      );
    }
  }
}
