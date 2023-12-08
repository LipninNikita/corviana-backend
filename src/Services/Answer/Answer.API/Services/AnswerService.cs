using Answer.API.Data;
using Answer.API.DTO;

namespace Answer.API.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly AppDbContext _dbContext;
        public AnswerService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Add(AddAnswer input)
        {
            Data.Models.Answer result = input;
            await _dbContext.Answers.AddAsync(result);
            await _dbContext.SaveChangesAsync();

            return result.Id;

        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AnswerOutput>> GetByQuestionId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Update(UpdateAnswer input)
        {
            throw new NotImplementedException();
        }
    }
}
