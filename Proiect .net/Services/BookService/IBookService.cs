using Proiect_.net.Models;

namespace Proiect_.net.Services.BookService
{
    public interface IBookService
    {
        public Task CreateBook(string ISBN, string Title, string? Description, int PageNumber, string Language, int ReleaseDate);
        public Task DeleteBookById(Guid BookId);
        public Task<Book?> GetBookById(Guid BookId);
        public Task<IEnumerable<Book>> GetAllBooks();     
    }
}
