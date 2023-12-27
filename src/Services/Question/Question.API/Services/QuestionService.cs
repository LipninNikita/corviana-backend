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
            Data.Models.Question model = input;
            await _dbContext.Questions.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return model.Id;
        }

        public async Task<IEnumerable<QuestionOutput>> GetAll()
        {
            var result = await _dbContext.Questions.Select(x => (QuestionOutput)x).ToListAsync();

            return result;
        }
    }
}
