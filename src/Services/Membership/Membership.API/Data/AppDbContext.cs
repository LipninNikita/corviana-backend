using Membership.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Membership.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserMembership> UserMemberships { get; set; }
    }
}
