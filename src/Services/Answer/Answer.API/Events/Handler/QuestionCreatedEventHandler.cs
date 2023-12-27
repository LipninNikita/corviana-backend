using Answer.API.Data;
using Answer.API.DTO;
using Answer.API.Events.Models;
using EventBusRabbitMq.Events;
using Services.Common.Middlewares.Exceptions;

namespace Answer.API.Events.Handler
{
    public class QuestionCreatedEventHandler : IEventHandler<QuestionCreatedEvent>
    {
        private readonly AppDbContext _dbContext;

        public QuestionCreatedEventHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(QuestionCreatedEvent @event)
        {
            if(@event.Answers != null && @event.Answers.Count() > 0)
            {
                var models = new List<Data.Models.Answer>();

                foreach (var item in @event.Answers)
                {
                    models.Add(new AddAnswer() { Content = item.Content, IsRight = item.IsRight, IdQuestion = int.Parse(@event.QuestionId) });
                }
                await _dbContext.Answers.AddRangeAsync(models);
                await _dbContext.SaveChangesAsync();
            }
            else
                throw new InvalidInputDataException();

            return true;
        }
    }
}
