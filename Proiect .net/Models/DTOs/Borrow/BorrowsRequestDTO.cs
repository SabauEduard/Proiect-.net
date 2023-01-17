using System.ComponentModel.DataAnnotations;

namespace Proiect_.net.Models.DTOs.Borrow
{
    public class BorrowsRequestDTO
    {
        [Required]
        public Guid BookId { get; set; }
        [Required]
        public Guid UserId { get; set; }
    }
}
