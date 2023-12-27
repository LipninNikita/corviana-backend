using EventBusRabbitMq.Events;
using Quest.API.Events.Models;
using Quest.API.Services;

namespace Quest.API.Events.Handlers
{
    public class QuestionAnsweredSuccessfulEventHandler : IEventHandler<QuestionAnsweredSuccessfulEvent>
    {
        private readonly IQuestService _questService;
        public QuestionAnsweredSuccessfulEventHandler(IQuestService questService)
        {
            _questService = questService;
        }

        public async Task<bool> Handle(QuestionAnsweredSuccessfulEvent @event)
        {
            var result = await _questService.IncrementQuestCounter(@event.UserId, Data.Models.QuestType.FinishQuestion);

            return result;
        }
    }
}
