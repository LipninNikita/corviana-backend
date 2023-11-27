using Identity.API.DTO.Input;
using Microsoft.AspNetCore.Identity;

namespace Identity.API.Services.Login
{
    public interface IAuthService
    {
        Task<bool> SignInAsync(SignInInput loginInputModel);
        Task<IdentityResult> SignUpAsync(SignUpInput user);
    }
}
