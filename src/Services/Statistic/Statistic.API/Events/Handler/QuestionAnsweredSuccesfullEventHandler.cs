using EventBusRabbitMq.Events;
using Statistic.API.DTO;
using Statistic.API.Events.Models;
using Statistic.API.Services;

namespace Statistic.API.Events.Handler
{
    public class QuestionAnsweredSuccesfullEventHandler : IEventHandler<QuestionAnsweredSuccessfulEvent>
    {
        private readonly IStatisticService _statisticService;

        public QuestionAnsweredSuccesfullEventHandler(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        public async Task<bool> Handle(QuestionAnsweredSuccessfulEvent @event)
        {
            await _statisticService.Add(new AddStatistic() { IsRightAnswered = true, QuestionId = @event.QuestionId, UserId = @event.UserId });

            return true;
        }
    }
}
