using Proiect_.net.Models;
using Proiect_.net.Repositories.GenericRepository;

namespace Proiect_.net.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public IEnumerable<User?> FindByFirstName(string FirstName);
        public IEnumerable<User?> FindByLastName(string LastName);
        public User? FindByEmail(string Email);
        public User? FindByUsername(string Username);
        public IEnumerable<Book?> BoooksBorrowedByUser(Guid UserId);
        public IEnumerable<User?> PenaltiesOfUsers();
    }
}
