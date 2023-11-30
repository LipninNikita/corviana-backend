using Microsoft.EntityFrameworkCore;
using PostComments.API.Data.Models;

namespace PostComments.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<PostComment> PostComments { get; set; }
    }
}
