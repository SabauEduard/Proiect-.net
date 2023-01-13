using Proiect_.net.Models;

namespace Proiect_.net.Services
{
    public interface IBookService
    {
        public Task CreateBook(string ISBN, string Title, string? Description, int PageNumber, string Language, int ReleaseDate);
        public Task DeleteBook(Guid BookId);
        public Task<Book?> GetBook(Guid BookId);
        public Task<IEnumerable<Book>> GetAllBooks();
        
    }
}
