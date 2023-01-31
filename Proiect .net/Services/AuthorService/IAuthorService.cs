using Proiect_.net.Models;
using Proiect_.net.Models.DTOs.Authors;

namespace Proiect_.net.Services.AuthorService
{
    public interface IAuthorService
    {
        public Task CreateAuthor(string LastName, string FirstName, string? Nationality);
        public Task DeleteAuthorById(Guid AuthorId);
        public Task<AuthorResponseDTO?> GetAuthorById(Guid AuthorId);
        public Task<IEnumerable<AuthorWBookResponseDTO>> GetAllAuthors();


    }
}
