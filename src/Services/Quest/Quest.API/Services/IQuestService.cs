using Quest.API.DTO;

namespace Quest.API.Services
{
    public interface IQuestService
    {
        public Task<Guid> Add(AddQuest input);
        public Task<QuestCard> GetById(Guid id);
        public Task<IEnumerable<QuestCard>> GetByUserId(string userId);
    }
}
