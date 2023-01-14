using Microsoft.Data.SqlClient;
using Proiect_.net.DataBase;
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
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IBookRepository bookRepository, IAuthorRepository authorRepository, IUserRepository userRepository, 
            ICategoryRepository categoryRepository, IWritesRepository writesRepository, IBelongsRepository belongsRepository,
            IBorrowsRepository borrowsRepository, IPenaltyRepository penaltyRepository, IPenaltyReceiptRepository penaltyReceiptRepository,
            DataBaseContext dbcontext)
        {
            this.bookRepository = bookRepository;
            this.authorRepository = authorRepository;
            this.userRepository = userRepository;
            this.categoryRepository = categoryRepository;
            this.writesRepository = writesRepository;
            this.belongsRepository = belongsRepository;
            this.borrowsRepository = borrowsRepository;
            this.penaltyRepository = penaltyRepository;
            this.penaltyReceiptRepository = penaltyReceiptRepository;
            _dbcontext = dbcontext;
        }
        public IWritesRepository writesRepository { get; set; }
        public IBelongsRepository belongsRepository { get; set; }
        public IBorrowsRepository borrowsRepository { get; set; }
        public IPenaltyRepository penaltyRepository { get; set; }
        public IPenaltyReceiptRepository penaltyReceiptRepository { get; set; }
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
