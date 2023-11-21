using Interaction.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Interaction.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<LikeInteraction> LikeInteractions { get; set; }
        public DbSet<ViewInteraction> ViewInteractions { get; set; }
    }
}
