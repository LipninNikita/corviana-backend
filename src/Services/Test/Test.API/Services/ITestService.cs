using Test.API.DTO;

namespace Test.API.Services
{
    public interface ITestService
    {
        public Task<int> Add(AddTest input);
        public Task<TestOutput> GetById(int id);
        public Task<IEnumerable<TestArrOutput>> GetAll();
        public Task<bool> Finish(int testId);
    }
}
