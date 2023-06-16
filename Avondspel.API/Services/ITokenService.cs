using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Avondspel.API.Services
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> GetToken();
    }
}
