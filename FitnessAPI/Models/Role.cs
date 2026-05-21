using System.ComponentModel.DataAnnotations;

namespace FitnessAPI.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        public string RoleName { get; set; } = string.Empty;

        public ICollection<UserRole>? UserRoles { get; set; }
    }
}