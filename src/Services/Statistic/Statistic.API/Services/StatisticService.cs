using Microsoft.EntityFrameworkCore;
using Services.Common.Middlewares.Exceptions;
using Services.Common.UserAccessor;
using Statistic.API.Data;
using Statistic.API.Data.Models;
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

        public async Task<bool> Add(AddStatistic input)
        {
            var model = new QuestionStatistic() { IsRightAnswered = input.IsRightAnswered, QuestionId = input.QuestionId, UserId = input.UserId };

            var isExists = await _dbContext.QuestionStatistics.Where(x => x.UserId == input.UserId & x.QuestionId == input.QuestionId & x.IsRightAnswered == input.IsRightAnswered).AnyAsync();

            if (!isExists)
            {
                await _dbContext.QuestionStatistics.AddAsync(model);
                await _dbContext.SaveChangesAsync();
            }

            return true;
        }

        public async Task<QuestionStatisticOutput> GetQuestionStatistics(int id)
        {
            var result = await _dbContext.QuestionStatistics
                    .Where(x => x.QuestionId == id)
                    .GroupBy(x => x.IsRightAnswered)
                    .Select(g => new QuestionStatisticOutput
                    {
                        RightAnswers = g.Where(x => x.IsRightAnswered == true).Count(),
                        WrongAnswers = g.Where(x => x.IsRightAnswered == false).Count()
                    }).FirstOrDefaultAsync();

            if (result is null || result == default)
                throw new ContentNotFoundException();

            result.QuestionId = id;

            return result;
        }

        public async Task<IEnumerable<UserStatisticOutput>> GetUserStatistics(DateTime dtStart, DateTime dtEnd, string? userId = null)
        {
            if (userId == null)
                userId = _userAccessor.GetUserId();

            var isAdmin = _userAccessor.IsAdmin();
            if (!isAdmin || userId != _userAccessor.GetUserId())
                throw new ForbiddenException("Unable to get other user statistics");

            List<UserStatisticOutput> statistics = await _dbContext.QuestionStatistics
            .Where(s => s.UserId == userId && s.DtCreated.Date >= dtEnd && s.DtCreated.Date <= dtStart)
            .GroupBy(s => s.UserId)
            .Select(g => new UserStatisticOutput
            {
                UserId = g.Key,
                TotalAnswersToday = g.Count(),
                Date = dtStart
            })
            .ToListAsync();

            return statistics;
        }
    }
}
