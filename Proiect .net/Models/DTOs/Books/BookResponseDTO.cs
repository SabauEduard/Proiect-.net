namespace Proiect_.net.Models.DTOs.Books
{
    public class BookResponseDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ISBN  { get; set; }
        public string Description  { get; set; }
        public string Language  { get; set; }
        public int PageNumber   { get; set; }
        public int ReleaseDate  { get; set; }

        public BookResponseDTO(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            ISBN = book.ISBN;
            Description = book.Description;
            Language = book.Language;
            PageNumber = book.PageNumber;
            ReleaseDate = book.ReleaseDate;
        }
    }
}
