namespace Proiect_.net.Models.DTOs.Write
{
    public class WritesResponseDTO
    {
        public Guid Id;
        public Guid AuthorId;
        public Guid BookId;

        public WritesResponseDTO(Writes writes)
        {
            Id = writes.Id;
            AuthorId = writes.AuthorId;
            BookId = writes.BookId;
        }
    }
}
