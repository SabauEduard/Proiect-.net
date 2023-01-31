using Proiect_.net.Repositories.GenericRepository;
using Proiect_.net.DataBase;
using Proiect_.net.Models;
using Microsoft.EntityFrameworkCore;

namespace Proiect_.net.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DataBaseContext context) : base(context) { }

        public IEnumerable<User?> FindByFirstName(string FirstName)
        {
            return _table.Where(u => u.FirstName == FirstName);
        }

        public IEnumerable<User?> FindByLastName(string LastName)
        {
            return _table.Where(u => u.LastName == LastName);
        }

        public User? FindByEmail(string Email)
        {
            return _table.FirstOrDefault(u => u.Email == Email);
        }

        public User? FindByUsername(string Username)
        {
            return _table.FirstOrDefault(u => u.Username == Username);
        }

        public IEnumerable<Book?> BoooksBorrowedByUser(Guid UserId)
        {
            var books = from b in _context.BooksTable
                        join br in _context.BorrowsTable on b.Id equals br.BookId
                        where br.UserId == UserId
                        select b;
                        
            return books.ToList();
        }

        public IEnumerable<User?> PenaltiesOfUsers()
        {
            return _table.Include("Penalties");
        }
    }
}
