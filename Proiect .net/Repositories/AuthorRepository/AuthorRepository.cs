using Proiect_.net.Models;
using Proiect_.net.DataBase;
using Proiect_.net.Repositories.GenericRepository;

namespace Proiect_.net.Repositories.AuthorRepository
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(DataBaseContext context) : base(context) { }
        public IEnumerable<Author> FindByLastName(string LastName)
        {
            return _table.Where(a => a.LastName == LastName);
        }
        
        public IEnumerable<Author> FindByFirstName(string FirstName)
        {
            return _table.Where(a => a.FirstName == FirstName);
        }

        public IEnumerable<Author> FindByNationality(string Nationality)
        {
            return _table.Where(a => a.Nationality == Nationality);
        }
    }
}
