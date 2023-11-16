using Microsoft.EntityFrameworkCore;
using Storage.API.Data.Models;

namespace Storage.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Image> Images { get; set; }
    }
}
