using Microsoft.AspNetCore.Identity;
using tparf.Api.Entities;

namespace tparf.Api.Services
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user, List<IdentityRole<long>> role);
    }
}
