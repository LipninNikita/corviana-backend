using EventBusRabbitMq.Events;
using Question.API.Data;
using Question.API.Events.Models;

namespace Question.API.Events.Handlers
{
    public class TestCompletedEventHandler : IEventHandler<TestCompletedEvent>
    {
        private readonly AppDbContext _dbContext;

        public TestCompletedEventHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(TestCompletedEvent @event)
        {
            var questionsIdsArr = @event.QuestionIds.Split(";");
            foreach (var questionId in questionsIdsArr)
            {
                await _dbContext.UserQuestionTransactions.AddAsync(new Data.Models.UserQuestionTransaction() { QuestionId = int.Parse(questionId), UserId = @event.UserId });
            }
        }
    }
}
