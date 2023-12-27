using Microsoft.EntityFrameworkCore;

namespace Question.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Models.Question> Questions { get; set; }
    }
}
