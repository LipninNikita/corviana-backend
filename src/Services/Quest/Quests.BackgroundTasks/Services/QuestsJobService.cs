using EventBusRabbitMq;
using EventBusRabbitMq.Events;
using Hangfire;
using Quest.BackgroundTasks.Events.Models;

namespace Quest.BackgroundTasks.Services
{
    public class QuestsJobService : IQuestsJobService
    {
        private readonly IEventBus _bus;
        public QuestsJobService(IEventBus bus)
        {
            _bus = bus;
        }

        public async Task<bool> AddJob(Guid QuestId, DateTime dtEnd)
        {
            BackgroundJob.Schedule(() => PublishQuestOverdueEvent(QuestId), dtEnd);

            return true;
        }

        private async Task PublishQuestOverdueEvent(Guid QuestId)
        {
            await _bus.Publish(new QuestOverdueEvent() { QuestId = QuestId });
        }
    }
}
