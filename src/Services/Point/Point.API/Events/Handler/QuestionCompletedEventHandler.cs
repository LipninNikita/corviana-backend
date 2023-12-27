using EventBusRabbitMq.Events;
using Point.API.Data;
using Point.API.Events.Models;

namespace Point.API.Events.Handler
{
    public class QuestionCompletedEventHandler : IEventHandler<QuestionCompletedEvent>
    {
        private readonly AppDbContext _dbContext;
        public QuestionCompletedEventHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(QuestionCompletedEvent @event)
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

            return true;
        }
    }
}
