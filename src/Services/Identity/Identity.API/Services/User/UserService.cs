using Identity.API.DTO.Output;
using Identity.Data;
using Microsoft.EntityFrameworkCore;
using Services.Common.UserAccessor;

namespace Identity.API.Services.User
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        private readonly IUserAccessor _userAccessor;
        public UserService(AppDbContext dbContext, IUserAccessor userAccessor)
        {
            _dbContext = dbContext;
            _userAccessor = userAccessor;
        }
        public async Task<UserDetails> GetUserById(string id)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task<IEnumerable<UsersInfo>> GetUsers()
        {
            var users = await _dbContext.Users.ToListAsync();
            return users.Select(x => (UsersInfo)x);
        }
    }
}
