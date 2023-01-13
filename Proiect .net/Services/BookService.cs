using Proiect_.net.Models;
using Proiect_.net.Repositories.BookRepository;

namespace Proiect_.net.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task CreateBook(string ISBN, string Title, string? Description, int PageNumber, string Language, int ReleaseDate)
        {
            var book = new Book() { ISBN = ISBN, Title = Title, Description = Description, PageNumber = PageNumber,
                                    Language = Language, ReleaseDate = ReleaseDate};

            await _bookRepository.CreateAsync(book);
            await _bookRepository.SaveAsync();
        }

        public async Task DeleteBook(Guid BookId)
        {
            var book = await _bookRepository.FindByIdAsync(BookId);
            if (book == null)
                return;
            _bookRepository.Delete(book);
            await _bookRepository.SaveAsync();
        }
    
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
           return await _bookRepository.GetAllAsync();
        }

        public async Task<Book?> GetBook(Guid BookId)
        {
            return await _bookRepository.FindByIdAsync(BookId);
        }
    }
}
