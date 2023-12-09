using Microsoft.AspNetCore.Mvc;
using Question.API.Data.Models;
using Question.API.DTO;

namespace Question.API.Services
{
    public interface IQuestionService
    {
        public Task<IEnumerable<QuestionOutput>> GetAll();
        public Task<IEnumerable<QuestionOutput>> GetByIds(string ids);
        public Task<QuestionOutput> GetRandom(QuestionTypeEnum? type, QuestionLvlEnum? lvl);
        public Task<int> Add(AddQuestion input);
        public Task<int> Update(UpdateQuestion input);
        public Task Delete(int id);
    }
}
