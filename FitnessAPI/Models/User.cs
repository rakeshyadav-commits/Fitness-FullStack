using FitnessAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FitnessAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }

        public ICollection<UserRole>? UserRoles { get; set; }
    }
}