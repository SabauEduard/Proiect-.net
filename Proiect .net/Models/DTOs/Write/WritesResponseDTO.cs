namespace Proiect_.net.Models.DTOs.Write
{
    public class WritesResponseDTO
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public Guid BookId  { get; set; }

        public WritesResponseDTO(Writes writes)
        {
            Id = writes.Id;
            AuthorId = writes.AuthorId;
            BookId = writes.BookId;
        }
    }
}
