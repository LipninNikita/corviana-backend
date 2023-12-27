using Answer.API.DTO;

namespace Answer.API.Services
{
    public interface IAnswerService 
    {
        public Task<Guid> Add(AddAnswer input);
        public Task<IEnumerable<AnswerOutput>> GetByQuestionId(int id);
        public Task<AnswerQuestionOutput> Answer(AnswerQuestionInput input);
    }
}
