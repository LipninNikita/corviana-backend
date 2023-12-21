using Microsoft.EntityFrameworkCore;

namespace Answer.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public AppDbContext()
        {
        }

        public virtual DbSet<Models.Answer> Answers { get; set; }
    }
}
