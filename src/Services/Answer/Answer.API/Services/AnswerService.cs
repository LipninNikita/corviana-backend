using Answer.API.Data;
using Answer.API.DTO;
using Microsoft.EntityFrameworkCore;

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

        public async Task<AnswerOutput> GetByIds(string ids)
        {
            var idsArr = ids.Split(';');
            var result = await _dbContext.Answers.SingleOrDefaultAsync(x => idsArr.Contains(x.Id.ToString()));

            return result;
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
