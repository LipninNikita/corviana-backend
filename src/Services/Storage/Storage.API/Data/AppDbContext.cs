using Microsoft.EntityFrameworkCore;
using MediaStorage.API.Data.Models;

namespace MediaStorage.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Image> Images { get; set; }
    }
}
