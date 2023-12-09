using EventBusRabbitMq.Events;
using Point.API.Data;
using Point.API.Events.Models;
using Point.API.Services;
using System.ComponentModel.Design;

namespace Point.API.Events.Handler
{
    public class QuestCompletedEventHandler : IEventHandler<QuestCompletedEvent>
    {
        private readonly AppDbContext _dbContext;

        public QuestCompletedEventHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(QuestCompletedEvent @event)
        {
            var amount = 0;
            if (@event.Level == 0)
                amount = 10;
            else if (@event.Level == 1)
                amount = 30;
            else if (@event.Level == 2)
                amount = 50;

            await _dbContext.PointTransactions.AddAsync(new Data.Models.PointTransaction() { Amount = amount, UserId = @event.UserId });
            await _dbContext.SaveChangesAsync();
        }
    }
}
