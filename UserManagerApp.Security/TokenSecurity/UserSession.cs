using App.Services.Contracts;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;


namespace App.Security.TokenSecurity
{
    public class UserSession : IUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserSession()
        {
            var userName = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name))?.Value;
            return userName;
        }
    }
}
