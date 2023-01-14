using Proiect_.net.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Proiect_.net.Models.DTOs.Users
{
    public class UserRequestDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public Role Role { get; set; }

    }
}
