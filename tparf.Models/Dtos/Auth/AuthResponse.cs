using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tparf.Models.Dtos.Auth
{
    public class AuthResponse
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Token { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
    }
}
