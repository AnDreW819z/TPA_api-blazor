using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using tparf.Api.Interfaces;
using tparf.Models.Dtos.Auth;

namespace tparf.Api.Services
{
    public class EmailConfirmService : IEmailConfirmService
    {
        private UserManager<IdentityUser> _userManger;
        private IConfiguration _configuration;
        private IMailService _mailService;
        public EmailConfirmService(UserManager<IdentityUser> userManager, IConfiguration configuration, IMailService mailService)
        {
            _userManger = userManager;
            _configuration = configuration;
            _mailService = mailService;
        }
        public async Task<Status> ConfirmEmailAsync(string email, string token)
        {
            var user = await _userManger.FindByEmailAsync(email);
            if (user == null)
                return new Status
                {
                    StatusCode = 404,
                    Message = "Пользователь с такой почтой не найден"
                };

            var decodedToken = WebEncoders.Base64UrlDecode(token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManger.ConfirmEmailAsync(user, normalToken);

            if (result.Succeeded)
                return new Status
                {
                    Message = "Почта успешно подтверждена",
                    StatusCode = 200,
                };

            return new Status
            {
                StatusCode = 400,
                Message = "Почта не подтверждена"
            };
        }
    }
}
