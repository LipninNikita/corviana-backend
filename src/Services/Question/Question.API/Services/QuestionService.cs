using EventBusRabbitMq;
using Microsoft.EntityFrameworkCore;
using Question.API.Data;
using Question.API.Data.Models;
using Question.API.DTO;
using Question.API.Events.Models;
using Services.Common.UserAccessor;

namespace Question.API.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly AppDbContext _dbContext;
        private readonly IEventBus _bus;
        private readonly IUserAccessor _userAccessor;
        public QuestionService(AppDbContext dbContext, IEventBus bus, IUserAccessor userAccessor)
        {
            _dbContext = dbContext;
            _bus = bus;
            _userAccessor = userAccessor;
        }

        public async Task<int> Add(AddQuestion input)
        {
            Data.Models.Question result = input;
            await _dbContext.Questions.AddAsync(result);
            await _dbContext.SaveChangesAsync();

            return result.Id;
        }

        public async Task AnswerQuestion(int QuestionId, bool IsSuccess)
        {
            var userId = _userAccessor.GetUserId();
            var question = await _dbContext.Questions.SingleOrDefaultAsync(x => x.Id == QuestionId);

            var transaction = new Data.Models.UserQuestionTransaction();
            transaction.UserId = userId;
            transaction.QuestionId = QuestionId;

            _bus.Publish(new QuestionCompletedEvent() { QuestionId = question.Id.ToString(), Level = (int)question.Level, UserId = userId });
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<QuestionOutput>> GetAll()
        {
            var result = await _dbContext.Questions.ToListAsync();

            return result.Select(x => (QuestionOutput)x);
        }

        public async Task<IEnumerable<QuestionOutput>> GetByIds(string ids)
        {
            var idsArr = ids.Split(';');
            var result = await _dbContext.Questions.Where(x => idsArr.Contains(x.Id.ToString())).ToListAsync();

            return result.Select(x => (QuestionOutput)x);
        }

        public async Task<QuestionOutput> GetRandom(QuestionTypeEnum? type, QuestionLvlEnum? lvl)
        {
            var query = _dbContext.Questions.AsQueryable();

            if (type != null)
                query.Where(x => x.Type == type);

            if (lvl != null)
                query.Where(x => x.Level == lvl);

            var amount = await query.CountAsync();
            var randomizedSkip = new Random().Next(0, amount);

            var result = await query.Skip(randomizedSkip).Take(1).SingleOrDefaultAsync();

            return result;
        }

        public Task<int> Update(UpdateQuestion input)
        {
            throw new NotImplementedException();
        }
    }
}
