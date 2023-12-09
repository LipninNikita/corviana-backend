using Microsoft.EntityFrameworkCore;
using Services.Common.UserAccessor;
using Statistic.API.Data;
using Statistic.API.DTO;

namespace Statistic.API.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly AppDbContext _dbContext;
        private readonly IUserAccessor _userAccessor;
        public StatisticService(AppDbContext dbContext, IUserAccessor userAccessor)
        {
            _dbContext = dbContext;
            _userAccessor = userAccessor;
        }

        public async Task<IEnumerable<StatisticOutput>> GetUserStatistic()
        {
            var userId = _userAccessor.GetUserId();

            DateTimeOffset twoWeeksAgo = DateTimeOffset.UtcNow.Date.AddDays(-14);
            DateTimeOffset today = DateTimeOffset.UtcNow.Date;

            List<StatisticOutput> statistics = _dbContext.Statistics
                .Where(s => s.UserId == userId && s.DtCreated.Date >= twoWeeksAgo && s.DtCreated.Date <= today)
                .GroupBy(s => s.UserId)
                .Select(g => new StatisticOutput
                {
                    UserId = g.Key,
                    TotalAnswersToday = g.Count(),
                    Date = today
                })
                .ToList();

            return statistics;
        }
    }
}
