using tparf.Models.Dtos.Auth;

namespace tparf.Web.Services.Contracts
{
    public interface IAuthenticationService
    {
        public Task<LoginResponse> Login(LoginModel model);
        Task Logout();
    }
}
