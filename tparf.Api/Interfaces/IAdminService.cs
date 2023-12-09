using tparf.Models.Dtos.Auth;

namespace tparf.Api.Interfaces
{
    public interface IAdminService
    {
        Task<Status> SeedRolesAsync();
        Task<Status> MakeOwnerAsync(UpdatePermissionDto updatePermissionDto);
        Task<Status> MakeAdminAsync(UpdatePermissionDto updatePermissionDto);
    }
}
