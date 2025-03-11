using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography;
using System.Text;

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

            builder.HasOne(u => u.Storage)
                .WithMany(s => s.Users)
                .HasForeignKey(u => u.StorageId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.SentSubmissions)
                .WithOne(s => s.FromUser)
                .HasForeignKey(s => s.FromUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.ReceivedSubmissions)
                .WithOne(s => s.ToUser)
                .HasForeignKey(s => s.ToUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Password hashing function using SHA-256
            string HashPassword(string password)
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                    StringBuilder builder = new StringBuilder();
                    foreach (var b in bytes)
                        builder.Append(b.ToString("x2"));
                    return builder.ToString();
                }
            }
            bool VerifyPassword(string inputPassword, string storedHash)
            {
                string inputHash = HashPassword(inputPassword);
                return inputHash.Equals(storedHash, StringComparison.OrdinalIgnoreCase);
            }


            // Seed Data
            builder.HasData(
                new User
                {
                    Id = Guid.Parse("d8f0b849-d1a2-45d5-8a23-47772060c8f1"),
                    FullName = "Admin",
                    Email = "admin@example.com",
                    PasswordHash = HashPassword("Admin@123"),
                    RoleId = Guid.Parse("a3c27f19-e401-46d0-b404-99fa35744e9e") // Admin Role
                },
                new User
                {
                    Id = Guid.Parse("d8f0b849-d1a2-45d5-8a23-47772060c8f2"),
                    FullName = "Staff 1",
                    Email = "staff@example.com",
                    PasswordHash = HashPassword("Staff@123"),
                    RoleId = Guid.Parse("9c157f3e-d3ac-43b8-93b0-15e3d7f40ec1"), // Staff Role
                    StorageId = 1
                },
                new User
                {
                    Id = Guid.Parse("5908232b-11d1-4c80-b330-f3810ed0d4a1"),
                    FullName = "Staff 2",
                    Email = "staff2@example.com",
                    PasswordHash = HashPassword("Staff@123"),
                    RoleId = Guid.Parse("9c157f3e-d3ac-43b8-93b0-15e3d7f40ec1"), // Staff Role
                    StorageId = 2
                },
                new User
                {
                    Id = Guid.Parse("d8f0b849-d1a2-45d5-8a23-47772060c8f3"),
                    FullName = "Manager",
                    Email = "manager@example.com",
                    PasswordHash = HashPassword("Manager@123"),
                    RoleId = Guid.Parse("09ac9b68-4b92-4f3b-b74e-2b1a5f6abf79") // Manager Role
                },
                new User
                {
                    Id = Guid.Parse("d8f0b849-d1a2-45d5-8a23-47772060c8f4"),
                    FullName = "MedComp inc.",
                    Email = "supplier@example.com",
                    PasswordHash = HashPassword("Supplier@123"),
                    RoleId = Guid.Parse("f8a8b1c9-24a1-484e-bb02-95b9601d4047") // Supplier Role
                },
                new User
                {
                    Id = Guid.Parse("996897c4-ef2b-4099-a9c5-5da1a06e9822"),
                    FullName = "L Corp.",
                    Email = "supplier2@example.com",
                    PasswordHash = HashPassword("Supplier@123"),
                    RoleId = Guid.Parse("f8a8b1c9-24a1-484e-bb02-95b9601d4047") // Supplier Role
                },
                new User
                {
                    Id = Guid.Parse("d8f0b849-d1a2-45d5-8a23-47772060c8f5"),
                    FullName = "Customer",
                    Email = "customer@example.com",
                    PasswordHash = HashPassword("Customer@123"),
                    RoleId = Guid.Parse("8bbdfc66-b6bb-4534-8c1c-c9a3b458ea3d") // Customer Role
                }
            );
        }
    }
}
