using tparf.Models.Dtos.Auth;

namespace tparf.Api.Interfaces
{
    public interface IEmailConfirmService
    {
        Task<Status> ConfirmEmailAsync(string email, string token);
    }
}
