using Identity.API.DTO.Output;

namespace Identity.API.Services.User
{
    public interface IUserService
    {
        public Task<UserDetails> GetUserById(string id);
        public Task<IEnumerable<UsersInfo>> GetUsers();
    }
}
