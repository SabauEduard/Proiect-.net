using Proiect_.net.Repositories.AuthorRepository;
using Proiect_.net.Repositories.BelongsRepository;
using Proiect_.net.Repositories.BookRepository;
using Proiect_.net.Repositories.BorrowsRepository;
using Proiect_.net.Repositories.CategoryRepository;
using Proiect_.net.Repositories.PenaltyReceiptRepository;
using Proiect_.net.Repositories.PenaltyRepository;
using Proiect_.net.Repositories.WritesRepository;

namespace Proiect_.net.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        public Task<bool> SaveAsync();
        public IBookRepository bookRepository { get; }
        public IAuthorRepository authorRepository { get; }
        public ICategoryRepository categoryRepository { get; }
        public IUserRepository userRepository { get; }
        public IWritesRepository writesRepository { get; }
        public IBelongsRepository belongsRepository { get; }
        public IBorrowsRepository borrowsRepository { get; }
        public IPenaltyRepository penaltyRepository { get; }
        public IPenaltyReceiptRepository penaltyReceiptRepository { get; }


    }
}
