using Identity.API.DTO.Output;
using Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace Identity.API.Services.User
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserDetails> GetUserById(string id)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Id ==  id);
            return user;
        }

        public async Task<IEnumerable<UsersInfo>> GetUsers()
        {
            var users = await _dbContext.Users.ToListAsync();
            return users.Select(x => (UsersInfo)x);
        }
    }
}
