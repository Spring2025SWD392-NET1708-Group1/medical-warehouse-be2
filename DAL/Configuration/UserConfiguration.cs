using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.PasswordHash)
                .IsRequired();

            builder.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.LotRequests)
                .WithOne(lr => lr.User)
                .HasForeignKey(lr => lr.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed Data
            builder.HasData(
                new User
                {
                    Id = Guid.Parse("d8f0b849-d1a2-45d5-8a23-47772060c8fc"),
                    FullName = "xhuyz",
                    Email = "admin@example.com",
                    PasswordHash = "12345",
                    RoleId = Guid.Parse("a3c27f19-e401-46d0-b404-99fa35744e9e") // Assuming RoleId is a Guid
                }
            );
        }
    }
}
