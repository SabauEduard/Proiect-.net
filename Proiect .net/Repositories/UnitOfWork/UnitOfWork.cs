using Microsoft.Data.SqlClient;
using Proiect_.net.DataBase;
using Proiect_.net.Repositories.AuthorRepository;
using Proiect_.net.Repositories.BookRepository;
using Proiect_.net.Repositories.CategoryRepository;

namespace Proiect_.net.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IBookRepository bookRepository, IAuthorRepository authorRepository, IUserRepository userRepository, ICategoryRepository categoryRepository, DataBaseContext dbcontext)
        {
            this.bookRepository = bookRepository;
            this.authorRepository = authorRepository;
            this.userRepository = userRepository;
            this.categoryRepository = categoryRepository;
            _dbcontext = dbcontext;
        }

        public IBookRepository bookRepository { get; set; }
        public IAuthorRepository authorRepository { get; set; }
        public IUserRepository userRepository { get; set; }
        public ICategoryRepository categoryRepository { get; set; }

        private DataBaseContext _dbcontext { get; set; }
        
        public async Task<bool> SaveAsync()
        {
            try
            {
                return await _dbcontext.SaveChangesAsync() > 0;
            }
            catch (SqlException exception)
            {
                Console.WriteLine("Oops...");
                Console.WriteLine(exception.Message);
            }
            return false;
        }
    }
}
