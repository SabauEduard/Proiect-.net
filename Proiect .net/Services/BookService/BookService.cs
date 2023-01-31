using Proiect_.net.Models;
using Proiect_.net.Models.DTOs.Books;
using Proiect_.net.Repositories.UnitOfWork;

namespace Proiect_.net.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateBook(string ISBN, string Title, string? Description, int PageNumber, string Language, int ReleaseDate)
        {
            var book = new Book()
            {
                ISBN = ISBN,
                Title = Title,
                Description = Description,
                PageNumber = PageNumber,
                Language = Language,
                ReleaseDate = ReleaseDate
            };

            await _unitOfWork.bookRepository.CreateAsync(book);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteBookById(Guid BookId)
        {
            var book = await _unitOfWork.bookRepository.FindByIdAsync(BookId);
            if (book == null)
                return;
            _unitOfWork.bookRepository.Delete(book);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<BookResponseDTO>> GetAllBooks()
        {
            var books = await _unitOfWork.bookRepository.GetAllAsync();
            return books.ConvertAll(b => new BookResponseDTO(b));
        }

        public async Task<BookResponseDTO?> GetBookById(Guid BookId)
        {
            var book = await _unitOfWork.bookRepository.FindByIdAsync(BookId);
            return new BookResponseDTO(book);
        }
    }
}
