using tparf.Models.Dtos.Auth;

namespace tparf.Web.Services.Contracts
{
    public interface IAuthenticationService
    {
        Task<AuthResponse> Login(AuthRequest model);
        Task Logout();
    }
}
