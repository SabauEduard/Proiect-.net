using Proiect_.net.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Proiect_.net.Models.DTOs.Users
{
    public class UserLoginRequestDTO
    {
        [Required]
        public string Username { get; set; }                
        [Required]
        public string Password { get; set; }
    }
}
