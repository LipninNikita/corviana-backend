using Answer.API.DTO;

namespace Answer.API.Services
{
    public interface IAnswerService 
    {
        public Task<Guid> Add(AddAnswer input);
        public Task<Guid> Update(UpdateAnswer input);
        public Task Delete(Guid id);
        public Task<IEnumerable<AnswerOutput>> GetByQuestionId(int id);
        public Task<IEnumerable<AnswerOutput>> GetByIds(string ids);
        public Task<CheckQuestionOutput> CheckQuestion(int questionId);
    }
}
