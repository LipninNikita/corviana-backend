using Microsoft.EntityFrameworkCore;
using Point.API.Data.Models;

namespace Point.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PointTransaction> PointTransactions { get; set; }
    }
}
