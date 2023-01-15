using Proiect_.net.Repositories.GenericRepository;
using Proiect_.net.Models;

namespace Proiect_.net.Repositories.AuthorRepository
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        public IEnumerable<Author> FindByLastName(string LastName);
        public IEnumerable<Author> FindByFirstName(string FirstName);
        public IEnumerable<Author> FindByNationality(string Nationality);
        public IEnumerable<(Guid, int)> NumberOfBooksByAuthors();
    }
}
