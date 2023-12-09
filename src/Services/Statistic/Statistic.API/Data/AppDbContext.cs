using Microsoft.EntityFrameworkCore;

namespace Statistic.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Models.UserStatistic> Statistics { get; set; }
    }
}
