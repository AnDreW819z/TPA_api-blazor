using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using tparf.Api.Entities;
using tparf.Models.Dtos.Auth;

namespace tparf.Api.Services
{
    public interface ITokenService
    {
        TokenResponse GetToken(IEnumerable<Claim> claim);
        string GetRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
