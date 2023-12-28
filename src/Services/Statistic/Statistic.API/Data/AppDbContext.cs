using Microsoft.EntityFrameworkCore;

namespace Statistic.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }
        public AppDbContext()
        {
        }
        public DbSet<Models.QuestionStatistic> QuestionStatistics { get; set; }
    }
}
