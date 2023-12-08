using Microsoft.EntityFrameworkCore;

namespace Answer.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Models.Answer> Answers { get; set; }
    }
}
