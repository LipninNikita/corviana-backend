using Answer.API.Data;
using Answer.API.DTO;
using Answer.API.Events.Models;
using EventBusRabbitMq;
using Microsoft.EntityFrameworkCore;
using Services.Common.Middlewares.Exceptions;

namespace Answer.API.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly AppDbContext _dbContext;
        private readonly IEventBus _bus;
        public AnswerService(AppDbContext dbContext, IEventBus bus)
        {
            _dbContext = dbContext;
            _bus = bus;
        }

        public async Task<Guid> Add(AddAnswer input)
        {
            Data.Models.Answer result = input;
            await _dbContext.Answers.AddAsync(result);
            await _dbContext.SaveChangesAsync();

            return result.Id;

        }

        public async Task<AnswerQuestionOutput> Answer(AnswerQuestionInput input)
        {
            var answers = await _dbContext.Answers.Where(x => x.QuestionId == input.QuestionId).ToListAsync();
            var rightAnswers = answers.Where(x => x.IsRight == true);
            var wrongAnswers = answers.Where(x => x.IsRight == false);

            var numberOfRightAnswered = answers.Count(x => x.IsRight && input.SelectedAnswers.Contains(x.Id));
            var totalRightAnswers = rightAnswers.Count();

            var result = new AnswerQuestionOutput() { IsSuccess = false, QuestionId = input.QuestionId, RightAnswers = rightAnswers.Select(x => x.Id), WrongAnswers = wrongAnswers.Select(x => x.Id) };

            if (numberOfRightAnswered == totalRightAnswers)
            {
                result.IsSuccess = true;

                var questionAnsweredSuccessfulEvent = new QuestionAnsweredSuccessfulEvent() { QuestionId = input.QuestionId};
                _bus.Publish(questionAnsweredSuccessfulEvent);

                return result;
            }

            var questionAnsweredWrongEvent = new QuestionAnsweredWrongEvent() { QuestionId= input.QuestionId};
            _bus.Publish(questionAnsweredWrongEvent);

            return result;
        }

        public async Task<IEnumerable<AnswerOutput>> GetByQuestionId(int id)
        {
            var answers = await _dbContext.Answers.Select(x => (AnswerOutput)x).ToListAsync();

            return answers;
        }
    }
}
