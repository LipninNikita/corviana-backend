using Statistic.API.DTO;

namespace Statistic.API.Services
{
    public interface IStatisticService
    {
        public Task<IEnumerable<StatisticOutput>> GetUserStatistic();
    }
}
