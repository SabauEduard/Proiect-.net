using Proiect_.net.Models;

namespace Proiect_.net.Services.AuthorService
{
    public interface IAuthorService
    {
        public Task CreateAuthor(string LastName, string FirstName, string? Nationality);
        public Task DeleteAuthorById(Guid AuthorId);
        public Task<Author> GetAuthorById(Guid AuthorId);
        public Task<IEnumerable<Author>> GetAllAuthors();
       
    }
}
