using EventBusRabbitMq;
using Quest.API.Data;
using Quest.API.Data.Models;
using Quest.API.DTO;
using Quest.API.Events.Models;
using System.Data.Entity;

namespace Quest.API.Services
{
    public class QuestService : IQuestService
    {
        private readonly AppDbContext _dbContext;
        private readonly IEventBus _bus;

        public QuestService(AppDbContext dbContext, IEventBus bus)
        {
            _dbContext = dbContext;
            _bus = bus;
        }

        public async Task<Guid> UpdateStatus(Guid id, bool IsSuccess)
        {
            var quest = await _dbContext.Quests.SingleOrDefaultAsync(x => x.Id == id);
            quest.IsFinished = true;
            quest.IsSucceed = IsSuccess;

            await _dbContext.SaveChangesAsync();

            return quest.Id;
        }

        public async Task<IEnumerable<QuestCard>> GetByUserId(string userId)
        {
            var result = await _dbContext.Quests.Where(x => x.IdUser == userId && x.IsFinished == false).ToListAsync();

            return result.Select(x => (QuestCard)x);
        }

        public async Task<bool> IncrementQuestCounter(string userId, QuestType type, int amount = 0)
        {
            var quests = await _dbContext.Quests.Where(x => x.IdUser == userId && x.QuestType == type && x.IsFinished == false).ToListAsync();
            if (quests is not null && quests != null && quests.Count() > 0)
            {
                foreach (var quest in quests)
                {
                    quest.CurrentAmount = quest.CurrentAmount + 1;

                    if (quest.TimesToFinish == quest.CurrentAmount)
                    {
                        quest.IsSucceed = true;
                        quest.IsFinished = true;

                        _bus.Publish(new QuestCompletedEvent() { Level = quest.Level, QuestId = quest.Id, UserId = userId });
                    }
                }

                return true;
            }

            return false;
        }
    }
}
