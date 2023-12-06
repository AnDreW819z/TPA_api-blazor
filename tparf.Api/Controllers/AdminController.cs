using Microsoft.AspNetCore.Mvc;
using tparf.Api.Services;
using tparf.Models.Dtos.Auth;

namespace tparf.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AuthController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        [Route("seed-roles")]
        public async Task<IActionResult> SeedRoles()
        {
            var seerRoles = await _adminService.SeedRolesAsync();

            return Ok(seerRoles);
        }

        [HttpPost]
        [Route("make-admin")]
        public async Task<IActionResult> MakeAdmin([FromBody] UpdatePermissionDto updatePermissionDto)
        {
            var operationResult = await _adminService.MakeAdminAsync(updatePermissionDto);

            if (operationResult.StatusCode == 200)
                return Ok(operationResult);

            return BadRequest(operationResult);
        }

        [HttpPost]
        [Route("make-owner")]
        public async Task<IActionResult> MakeOwner([FromBody] UpdatePermissionDto updatePermissionDto)
        {
            var operationResult = await _adminService.MakeOwnerAsync(updatePermissionDto);

            if (operationResult.StatusCode == 200)
                return Ok(operationResult);

            return BadRequest(operationResult);
        }
    }
}
