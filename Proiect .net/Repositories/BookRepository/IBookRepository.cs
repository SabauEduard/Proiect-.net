using Proiect_.net.Models;
using Proiect_.net.Repositories.GenericRepository;

namespace Proiect_.net.Repositories.BookRepository
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        public Book FindByISBN(string ISBN);
        public IEnumerable<Book> FindByTitle(string Title);
        public IEnumerable<Book> FindByLanguage(string Language);
        public IEnumerable<Book> FindByPageNumber(int PageNumber);
    }
}
