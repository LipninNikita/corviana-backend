using Answer.API.Data;
using Answer.API.DTO;
using Microsoft.EntityFrameworkCore;
using Services.Common.Middlewares.Exceptions;

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

        public async Task<CheckQuestionOutput> CheckQuestion(int questionId)
        {
            var result = new CheckQuestionOutput();
            var answers = await _dbContext.Answers.Where(x => x.IdQuestion == questionId).ToListAsync();

            var wrong = answers.Where(x => x.IsRight == false).Select(x => x.Id);
            var right = answers.Where(x => x.IsRight == true).Select(x => x.Id);
            result.WrongAnswers = new List<Guid>(wrong);
            result.RightAnswers = new List<Guid>(right);
            result.IdQuestion = questionId;
            result.Annotation = answers.FirstOrDefault().Annotation;

            return result;
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AnswerOutput>> GetByIds(string ids)
        {
            var result = new List<Data.Models.Answer>();
            var idsArr = ids.Split(';');
            foreach (var id in idsArr)
            {
                var entity = await _dbContext.Answers.Where(x => x.IdQuestion == int.Parse(id)).ToArrayAsync();
                result.AddRange(entity);
            }
            //var result = await _dbContext.Answers.Where(x => idsArr.Contains(x.Id.ToString())).ToListAsync();

            return result.Select(x => (AnswerOutput)x);
        }

        public async Task<IEnumerable<AnswerOutput>> GetByQuestionId(int id)
        {
            var data = await _dbContext.Answers.Where(x => x.IdQuestion == id).ToListAsync();
            if (data.Count == 0)
                throw new ContentNotFoundException();

            return data.Select(x => (AnswerOutput)x);
        }

        public Task<Guid> Update(UpdateAnswer input)
        {
            throw new NotImplementedException();
        }
    }
}
