using Question.API.Data;
using Question.API.Data.Models;
using Question.API.DTO;
using System.Data.Entity;

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
            Data.Models.Question result = input;
            await _dbContext.Questions.AddAsync(result);
            await _dbContext.SaveChangesAsync();

            return result.Id;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<QuestionOutput>> GetByIds(string ids)
        {
            var result = await _dbContext.Questions.Where(x => ids.Contains(x.Id.ToString())).ToListAsync();

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
