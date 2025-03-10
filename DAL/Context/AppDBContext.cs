using DAL.Configuration;
using DAL.Configurations;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemCategory> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<LotRequest> LotRequests { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<StorageCategory> StorageCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new SubmissionConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new LotRequestConfiguration());
            modelBuilder.ApplyConfiguration(new StorageConfiguration());
            modelBuilder.ApplyConfiguration(new StorageCategoryConfiguration());
        }
    }
}
