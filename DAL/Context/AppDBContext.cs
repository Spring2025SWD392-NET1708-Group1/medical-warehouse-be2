using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace DAL.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Products { get; set; } = null!;
        // Constructor accepting DbContextOptions
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        // OnModelCreating method to apply configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply all configurations from the assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}

