using Microsoft.AspNetCore.Mvc;
using Question.API.Data.Models;
using Question.API.DTO;

namespace Question.API.Services
{
    public interface IQuestionService
    {
        public Task<IEnumerable<QuestionOutput>> GetAll();
        public Task<int> Add(AddQuestion input);
    }
}
