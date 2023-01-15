using Proiect_.net.Models;
using Proiect_.net.Models.DTOs.Authors;
using Proiect_.net.Repositories.UnitOfWork;

namespace Proiect_.net.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAuthor(string LastName, string FirstName, string? Nationality)
        {
            var author = new Author()
            {
                LastName = LastName,
                FirstName = FirstName,
                Nationality = Nationality
            };

            await _unitOfWork.authorRepository.CreateAsync(author);
            await _unitOfWork.SaveAsync();
        }        
        public async Task DeleteAuthorById(Guid AuthorId)
        {
            var author = await _unitOfWork.authorRepository.FindByIdAsync(AuthorId);
            if (author == null)
                return;
            _unitOfWork.authorRepository.Delete(author);
            await _unitOfWork.SaveAsync();
        }
        public async Task<Author> GetAuthorById(Guid AuthorId)
        {
            return await _unitOfWork.authorRepository.FindByIdAsync(AuthorId);
        }

        public async Task<IEnumerable<AuthorResponseDTO>> GetAllAuthors()
        {
            var numberOfBooksByAuthor = _unitOfWork.authorRepository.NumberOfBooksByAuthors();
            var authors = await _unitOfWork.authorRepository.GetAllAsync();
            return authors.ConvertAll(a => new AuthorResponseDTO(a, numberOfBooksByAuthor.FirstOrDefault(x => x.Item1 == a.Id).Item2));
        }
    }
}
