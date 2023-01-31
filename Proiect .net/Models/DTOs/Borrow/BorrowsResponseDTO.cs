namespace Proiect_.net.Models.DTOs.Borrow
{
    public class BorrowsResponseDTO
    {
        Guid Id { get; set; }
        Guid BookId { get; set; }
        Guid UserId { get; set; }

        public BorrowsResponseDTO(Borrows borrows)
        {
            Id = borrows.Id;
            BookId = borrows.BookId;
            UserId = borrows.UserId;
        }
    }
}
