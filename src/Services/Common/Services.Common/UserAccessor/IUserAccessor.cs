﻿using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Services.Common.UserAccessor
{
    public interface IUserAccessor
    {
        public string? GetUserId();
        public string GetUserEmail();
        public bool IsMember();
        public bool IsAdmin();
    }
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly string? jwt;

        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
            //jwt = _contextAccessor.HttpContext.Request.Headers["Authorization"];
        }

        public string GetUserEmail()
        {
            throw new NotImplementedException();
        }

        public string? GetUserId()
        {
            //var token = new JwtSecurityTokenHandler().ReadJwtToken(jwt);
            var user = _contextAccessor.HttpContext.User;
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId != null)
            {
                return userId;
            }
            else
            {
                return null;
            }
        }

        public bool IsAdmin()
        {
            var user = _contextAccessor.HttpContext.User;
            var roles = user.FindAll(ClaimTypes.Role).Select(x => x.Value);
            if (roles.Contains("Admin"))
                return true;

            return false;
        }

        public bool IsMember()
        {
            var user = _contextAccessor.HttpContext.User;
            var roles = user.FindAll(ClaimTypes.Role).Select(x => x.Value);
            if (roles.Contains("IsMember"))
                return true;

            return false;
        }
    }
}
