using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tparf.Api.Entities
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? OrganizationName { get; set; }
        public long RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
        
    }
}
