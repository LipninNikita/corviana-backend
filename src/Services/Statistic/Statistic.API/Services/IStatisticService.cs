using Statistic.API.DTO;

namespace Statistic.API.Services
{
    public interface IStatisticService
    {
        public Task<IEnumerable<UserStatisticOutput>> GetUserStatistics(DateTime dtStart, DateTime dtEnd, string? userId = null);
        public Task<QuestionStatisticOutput> GetQuestionStatistics(int id);
        public Task<bool> Add(AddStatistic input);
    }
}
