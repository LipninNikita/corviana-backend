using Identity.API.DTO.Input;
using Microsoft.AspNetCore.Identity;

namespace Identity.API.Services.Login
{
    public interface IAuthService
    {
        Task<string> SignInAsync(SignInInput loginInputModel);
        Task<IdentityResult> SignUpAsync(SignUpInput user);
        public Task AddRole(string Name);
        public Task AddToTole(string Name, string userId);
    }
}
