using Proiect_.net.Repositories.GenericRepository;
using Proiect_.net.DataBase;
using Proiect_.net.Models;
using Microsoft.EntityFrameworkCore;

namespace Proiect_.net.Repositories.BookRepository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(DataBaseContext context) : base(context) { }

        public Book FindByISBN(string ISBN)
        {
            return _table.FirstOrDefault(b => b.ISBN == ISBN);
        }

        public IEnumerable<Book> FindByTitle(string title)
        {
            return _table.Where(b => b.Title == title);
        }

        public IEnumerable<Book> FindByLanguage(string Language)
        {
            return _table.Where(b => b.Language == Language);
        }

        public IEnumerable<Book> FindByPageNumber(int PageNumber)
        {
            return _table.Where(b => b.PageNumber == PageNumber);
        }

    }
}
