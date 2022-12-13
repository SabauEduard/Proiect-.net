using System.ComponentModel.DataAnnotations;

namespace Proiect_.net.Models.DTOs.Authors
{
    public class AuthorRequestDTO
    {
        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string Nationality { get; set; }
    }
}
