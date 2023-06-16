using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;

namespace Avondspel.API.Services
{
    public class TokenService : ITokenService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public TokenService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<JwtSecurityToken> GetToken()
        {
            var jwt = httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
            return new JwtSecurityToken(jwt);
        }
    }
}
