using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
  public class RoleConfiguration : IEntityTypeConfiguration<Role>
  {
    public void Configure(EntityTypeBuilder<Role> builder)
    {
      builder.HasKey(r => r.Id);

      builder.Property(r => r.Name)
          .IsRequired()
          .HasMaxLength(50);

      // Seed Data
      builder.HasData(
          new Role
          {
            Id = Guid.Parse("a3c27f19-e401-46d0-b404-99fa35744e9e"),
            Name = "Admin"
          },
          new Role
          {
            Id = Guid.Parse("9c157f3e-d3ac-43b8-93b0-15e3d7f40ec1"),
            Name = "Staff"
          },
          new Role
          {
            Id = Guid.Parse("8bbdfc66-b6bb-4534-8c1c-c9a3b458ea3d"),
            Name = "Customer"
          },
          new Role
          {
            Id = Guid.Parse("09ac9b68-4b92-4f3b-b74e-2b1a5f6abf79"),
            Name = "Manager"
          },
          new Role
          {
            Id = Guid.Parse("f8a8b1c9-24a1-484e-bb02-95b9601d4047"),
            Name = "Supplier"
          }
      );

    }
  }
}
