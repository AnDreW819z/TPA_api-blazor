using tparf.Models.Dtos.Auth;

namespace tparf.Api.Services
{
    public interface IEmailConfirmService
    {
        Task<Status> ConfirmEmailAsync(string email, string token);
    }
}
