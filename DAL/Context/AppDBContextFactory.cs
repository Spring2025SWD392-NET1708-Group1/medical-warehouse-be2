using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace DAL.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql(
                "Server=localhost;Database=MWS;Port=3306;User Id=root;Password=12345;",
                new MySqlServerVersion(new Version(8, 0, 2)) // Replace with your MySQL server version
            );

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
