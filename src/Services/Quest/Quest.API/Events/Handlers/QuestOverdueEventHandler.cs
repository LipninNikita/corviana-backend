using EventBusRabbitMq.Events;
using Quest.API.Events.Models;
using Quest.API.Services;

namespace Quest.API.Events.Handlers
{
    public class QuestOverdueEventHandler : IEventHandler<QuestOverdueEvent>
    {
        private readonly IQuestService _questService;

        public QuestOverdueEventHandler(IQuestService questService)
        {
            _questService = questService;
        }

        public async Task<bool> Handle(QuestOverdueEvent @event)
        {
            var result = await _questService.UpdateStatus(@event.QuestId);

            return true;
        }
    }
}
