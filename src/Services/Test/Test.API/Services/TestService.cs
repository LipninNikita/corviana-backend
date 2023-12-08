using Microsoft.EntityFrameworkCore;
using Services.Common.UserAccessor;
using Test.API.Data;
using Test.API.DTO;

namespace Test.API.Services
{
    public class TestService : ITestService
    {
        private readonly AppDbContext _dbContext;
        private readonly IUserAccessor _userAccessor;

        public TestService(AppDbContext dbContext, IUserAccessor userAccessor)
        {
            _dbContext = dbContext;
            _userAccessor = userAccessor;
        }

        public async Task<int> Add(AddTest input)
        {
            Data.Models.Test model = input;
            await _dbContext.Tests.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return model.Id;
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

        public Task<TestArrOutput> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
