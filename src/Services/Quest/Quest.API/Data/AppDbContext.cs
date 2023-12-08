using Microsoft.EntityFrameworkCore;

namespace Quest.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Models.Quest> Quests { get; set; }
    }
}
