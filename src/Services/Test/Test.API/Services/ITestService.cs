using Test.API.DTO;

namespace Test.API.Services
{
    public interface ITestService
    {
        public Task<int> Add(AddTest input);
        public Task<TestArrOutput> GetById(int id);
        public Task<IEnumerable<TestArrOutput>> GetAll();
    }
}
