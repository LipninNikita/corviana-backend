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
        public QuestionService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
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

        public async Task<string> GetHintByQuestionId(int id)
        {
            var hint = await _dbContext.Questions.Where(x => x.Id == id).Select(x => x.Hint).FirstOrDefaultAsync();

            return hint;
        }
    }
}
