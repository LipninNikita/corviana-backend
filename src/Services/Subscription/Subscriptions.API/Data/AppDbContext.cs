using Microsoft.EntityFrameworkCore;
using Subscriptions.API.Data.Models;

namespace Subscriptions.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Subscription> Subscriptions { get; set; }
    }
}
