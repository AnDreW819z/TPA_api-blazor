using tparf.Models.Dtos.Auth;

namespace tparf.Api.Services
{
    public interface IAuthService
    {
        Task<AuthServiceResponseDto> SeedRolesAsync();
        Task<AuthServiceResponseDto> MakeAdministratorAsync(UpdatePermissionDto updatePermissionDto);
        Task<AuthServiceResponseDto> MakeModeratorAsync(UpdatePermissionDto updatePermissionDto);
    }
}
