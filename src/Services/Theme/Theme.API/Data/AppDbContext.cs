using Microsoft.EntityFrameworkCore;

namespace Theme.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Models.Theme> Themes { get; set; }
    }
}
