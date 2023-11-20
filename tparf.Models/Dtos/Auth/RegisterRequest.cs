using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tparf.Models.Dtos.Auth
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        public string UserName { get; set; }

        [Required(ErrorMessage = "CompanyName is required")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; } = null!;
    }
}
