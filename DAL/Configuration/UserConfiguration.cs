using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DAL.Entities;
namespace DAL.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(150);
            builder.HasIndex(u => u.Email).IsUnique();
            // Relationships (One-to-Many: User -> Role)
            builder.HasMany(u => u.Role)
                   .WithOne(o => o.User)
                   .HasForeignKey(o => o.RoleID)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
                new User { Id = 1, Name = "Huy", Email = "huy12@gmail.com" },
                new User { Id = 2, Name = "Khoi", Email = "khoi12@gmail.com" }
                );
        }
    }
}
