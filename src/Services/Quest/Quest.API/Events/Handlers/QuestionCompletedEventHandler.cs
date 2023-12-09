using EventBusRabbitMq;
using EventBusRabbitMq.Events;
using Microsoft.EntityFrameworkCore;
using Quest.API.Data;
using Quest.API.Events.Models;

namespace Quest.API.Events.Handlers
{
    public class QuestionCompletedEventHandler : IEventHandler<QuestionCompeletedEvent>
    {
        private readonly AppDbContext _dbContext;
        private readonly IEventBus _bus;

        public QuestionCompletedEventHandler(AppDbContext dbContext, IEventBus bus)
        {
            _dbContext = dbContext;
            _bus = bus;
        }

        public async Task Handle(QuestionCompeletedEvent @event)
        {
            var quests = await _dbContext.Quests.Where(x => x.IdUser == @event.UserId).Where(x => x.IsFinished == false).Where(x => x.Level == @event.Level).Where(x => x.QuestType == Data.Models.QuestType.FinishQuestion).ToListAsync();

            if(quests != null && quests.Count() != 0)
            {
                foreach (var quest in quests)
                {
                    quest.CurrentAmount = quest.CurrentAmount + 1;
                    var currentAmount = quest.CurrentAmount;
                    if (quest.CurrentAmount == currentAmount)
                    {
                        quest.IsSucceed = true;

                        _bus.Publish(new QuestCompletedEvent() { Level = quest.Level, QuestId = quest.Id.ToString(), UserId = quest.IdUser });
                    }
                }

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
