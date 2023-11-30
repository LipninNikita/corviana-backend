using Microsoft.EntityFrameworkCore;
using Post.API.Data.Models;

namespace Post.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Models.Post> Posts { get; set; }
    }
}
