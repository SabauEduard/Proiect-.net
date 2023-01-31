namespace Proiect_.net.Models.DTOs.Belong
{
    public class BelongsResponseDTO
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid CategoryId { get; set; }
        
        public BelongsResponseDTO(Belongs belongs)
        {
            Id = belongs.Id;
            BookId = belongs.BookId;
            CategoryId = belongs.CategoryId;
        }
    }
}
