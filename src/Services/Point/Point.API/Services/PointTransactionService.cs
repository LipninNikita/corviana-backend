using Microsoft.EntityFrameworkCore;
using Point.API.Data;
using Point.API.DTO;
using Services.Common.UserAccessor;

namespace Point.API.Services
{
    public class PointTransactionService : IPointTransactionService
    {
        private readonly AppDbContext _dbContext;
        private readonly IUserAccessor _userAccessor;

        public PointTransactionService(AppDbContext dbContext, IUserAccessor userAccessor)
        {
            _dbContext = dbContext;
            _userAccessor = userAccessor;
        }

        public async Task<IEnumerable<LeaderboardOutput>> GetLeaderboard()
        {
            var topUsers = await _dbContext.PointTransactions
                       .GroupBy(u => u.UserId)
                       .Select(g => new LeaderboardOutput
                       {
                           UserId = g.Key,
                           Amount = g.Sum(x => x.Amount)
                       })
                       .OrderByDescending(o => o.Amount)
                       .Take(10)
                       .ToListAsync();

            return topUsers;
        }

        public async Task<LeaderboardOutput> GetUserPlace()
        {
            var userId = _userAccessor.GetUserId();

            var result = await _dbContext.PointTransactions
                       .GroupBy(u => u.UserId)
                       .Select(g => new LeaderboardOutput
                       {
                           UserId = g.Key,
                           Amount = g.Sum(x => x.Amount)
                       })
                       .OrderByDescending(o => o.Amount).SingleOrDefaultAsync(x => x.UserId == userId);

            return result;
        }
    }
}
