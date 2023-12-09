using EventBusRabbitMq.Events;
using Statistic.API.Data;
using Statistic.API.Events.Models;

namespace Statistic.API.Events.Handler
{
    public class QuestionCompletedEventHandler : IEventHandler<QuestionCompeletedEvent>
    {
        private readonly AppDbContext _dbContext;

        public QuestionCompletedEventHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(QuestionCompeletedEvent @event)
        {
            await _dbContext.Statistics.AddAsync(new Data.Models.UserStatistic() { DtCreated = DateTimeOffset.UtcNow, UserId = @event.UserId });
            await _dbContext.SaveChangesAsync();
        }
    }
}
