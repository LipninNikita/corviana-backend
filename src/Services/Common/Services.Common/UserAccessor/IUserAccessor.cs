﻿using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Services.Common.UserAccessor
{
    public interface IUserAccessor
    {
        public string GetUserId();
        public string GetUserEmail();
    }
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly string? jwt;

        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
            jwt = _contextAccessor.HttpContext.Request.Headers["Authorization"];
        }

        public string GetUserEmail()
        {
            throw new NotImplementedException();
        }

        public string GetUserId()
        {
            var token = new JwtSecurityTokenHandler().ReadJwtToken(jwt);
            var userId = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            return userId;
        }
    }
}
