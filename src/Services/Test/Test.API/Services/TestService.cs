using Microsoft.EntityFrameworkCore;
using Test.API.Data;
using Test.API.DTO;

namespace Test.API.Services
{
    public class TestService : ITestService
    {
        private readonly AppDbContext _dbContext;

        public TestService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Add(AddTest input)
        {
            Data.Models.Test model = input;
            await _dbContext.Tests.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return model.Id;
        }

        public Task<IEnumerable<TestArrOutput>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TestArrOutput> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
