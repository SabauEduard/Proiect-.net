using System.ComponentModel.DataAnnotations;

namespace Proiect_.net.Models.DTOs.Write
{
    public class WritesRequestDTO
    {
        [Required]
        public Guid BookId;
        [Required]
        public Guid AuthorId;
    }
}
