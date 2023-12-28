using Quest.API.Data.Models;
using Quest.API.DTO;

namespace Quest.API.Services
{
    public interface IQuestService
    {
        public Task<Guid> UpdateStatus(Guid id, bool IsSuccess);
        public Task<IEnumerable<QuestCard>> GetByUserId(string userId);
        public Task<bool> IncrementQuestCounter(string userId, QuestType type, int amount = 0);
    }
}
