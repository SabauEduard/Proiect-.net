using System.ComponentModel.DataAnnotations;

namespace Proiect_.net.Models.DTOs.Categories
{
    public class CategoryRequestDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
