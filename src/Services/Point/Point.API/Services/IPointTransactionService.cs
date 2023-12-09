using Point.API.DTO;

namespace Point.API.Services
{
    public interface IPointTransactionService
    {
        public Task<IEnumerable<LeaderboardOutput>> GetLeaderboard();
        public Task<LeaderboardOutput> GetUserPlace();
    }
}
