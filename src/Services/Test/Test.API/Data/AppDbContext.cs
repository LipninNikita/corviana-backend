using Microsoft.EntityFrameworkCore;

namespace Test.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Models.Test> Tests { get; set; }
    }
}
