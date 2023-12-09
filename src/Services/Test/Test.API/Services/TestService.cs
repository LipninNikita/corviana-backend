using EventBusRabbitMq;
using Microsoft.EntityFrameworkCore;
using Services.Common.UserAccessor;
using Test.API.Data;
using Test.API.DTO;
using Test.API.Events.Models;

namespace Test.API.Services
{
    public class TestService : ITestService
    {
        private readonly AppDbContext _dbContext;
        private readonly IUserAccessor _userAccessor;
        private readonly IEventBus _bus;

        public TestService(AppDbContext dbContext, IUserAccessor userAccessor, IEventBus bus)
        {
            _dbContext = dbContext;
            _userAccessor = userAccessor;
            _bus = bus;
        }

        public async Task<int> Add(AddTest input)
        {
            Data.Models.Test model = input;
            await _dbContext.Tests.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return model.Id;
        }

        public async Task<bool> Finish(int testId)
        {
            var userId = _userAccessor.GetUserId();
            if(userId != null)
            {
                await _dbContext.UserTestTransactions.AddAsync(new Data.Models.UserTestTransaction() { IsFinished = true, TestId = testId, UserId = userId });
                await _dbContext.SaveChangesAsync();

                var test = await _dbContext.Tests.SingleOrDefaultAsync(x => x.Id == testId);
                _bus.Publish(new TestCompletedEvent() { QuestionIds = test.QuestionIds, TestId = testId });
            }

            return true;
        }

        public async Task<IEnumerable<TestArrOutput>> GetAll()
        {
            var query = _dbContext.Tests.AsQueryable();

            var userId = _userAccessor.GetUserId();
            if(userId != null)
            {
                var transactions = await _dbContext.UserTestTransactions.Where(x => x.UserId == userId).ToListAsync();

                foreach (var item in transactions)
                {
                    query.Where(x => x.Id == item.TestId);
                }
            }

            var result = await query.ToListAsync();
            return result.Select(x => (TestArrOutput)x);
        }

        public async Task<TestOutput> GetById(int id)
        {
            var result = await _dbContext.Tests.SingleOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}
