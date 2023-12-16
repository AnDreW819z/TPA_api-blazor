using Microsoft.AspNetCore.Mvc;
using tparf.Api.EmailSender;
using tparf.Api.Interfaces;
using tparf.Models.Dtos.Auth;

namespace tparf.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IEmailService _emailService;

        public AuthController(IAdminService adminService, IEmailService emailService)
        {
            _adminService = adminService;
            _emailService = emailService;
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

        [HttpGet]
        public async Task<IActionResult> TestSend()
        {
            var message = new Message(new string[] { "wer_ander@mail.ru" }, "Test", "<h1>Тестовое письмо</h1>");
            await _emailService.SendEmail(message);
            return StatusCode(StatusCodes.Status200OK, new Status { Message = "Сообщение успешно отправлено", StatusCode = 200 });
        }
    }
}
