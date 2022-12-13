using System.ComponentModel.DataAnnotations;

namespace Proiect_.net.Models.DTOs.Books
{
    public class BookRequestDTO
    {
        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Language  { get; set; }

        public string Description { get; set; }
        public int PageNumber { get; set; }
        public int ReleaseDate { get; set; }

    }
}
