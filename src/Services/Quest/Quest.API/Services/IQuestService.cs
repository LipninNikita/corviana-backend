using Quest.API.Data.Models;
using Quest.API.DTO;

namespace Quest.API.Services
{
    public interface IQuestService
    {
        public Task<Guid> Add(AddQuest input);
        public Task<Guid> UpdateStatus(Guid id);
        public Task<QuestCard> GetById(Guid id);
        public Task<IEnumerable<QuestCard>> GetByUserId(string userId);
        public Task<bool> IncrementQuestCounter(string userId, QuestType type, int amount = 0);
    }
}
