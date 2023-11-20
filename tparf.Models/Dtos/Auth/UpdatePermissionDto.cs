using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tparf.Models.Dtos.Auth
{
    public class UpdatePermissionDto
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
    }
}
