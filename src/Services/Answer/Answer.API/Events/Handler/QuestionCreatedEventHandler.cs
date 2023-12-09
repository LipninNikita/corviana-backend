using Answer.API.Data;
using Answer.API.DTO;
using Answer.API.Events.Models;
using EventBusRabbitMq.Events;

namespace Answer.API.Events.Handler
{
    public class QuestionCreatedEventHandler : IEventHandler<QuestionCreatedEvent>
    {
        private readonly AppDbContext _dbContext;

        public QuestionCreatedEventHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(QuestionCreatedEvent @event)
        {
            var models = new List<AddAnswer>();
            foreach (var item in @event.Answers)
            {
                models.Add(new AddAnswer() { Content = item.Content, IsRight = item.IsRight, IdQuestion = int.Parse(@event.QuestionId), Annotation = item.Annotation });
            }

            await _dbContext.Answers.AddRangeAsync(models.Select(x => (Data.Models.Answer)x));
            await _dbContext.SaveChangesAsync();
        }
    }
}
