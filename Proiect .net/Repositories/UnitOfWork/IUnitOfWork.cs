using Proiect_.net.Repositories.AuthorRepository;
using Proiect_.net.Repositories.BookRepository;
using Proiect_.net.Repositories.CategoryRepository;

namespace Proiect_.net.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        public Task<bool> SaveAsync();
        public IBookRepository bookRepository { get; }
        public IAuthorRepository authorRepository { get; }
        public ICategoryRepository categoryRepository { get; }
        public IUserRepository userRepository { get; } 
    }
}
