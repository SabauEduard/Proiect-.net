using Proiect_.net.Models;
using Proiect_.net.Repositories.UnitOfWork;

namespace Proiect_.net.Services.WritesService
{
    public class WritesService : IWritesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WritesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateWrites(Guid AuthorId, Guid BookId)
        {
            var writes = new Writes() { AuthorId = AuthorId, BookId = BookId };
            await _unitOfWork.writesRepository.CreateAsync(writes);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteWritesById(Guid WritesId)
        {
            var writes = await _unitOfWork.writesRepository.FindByIdAsync(WritesId);
            if (writes is null)
                return;
            _unitOfWork.writesRepository.Delete(writes);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<Writes>> GetAllWrites()
        {
            return await _unitOfWork.writesRepository.GetAllAsync();
        }

        public async Task<Writes> GetWritesById(Guid WritesId)
        {
            return await _unitOfWork.writesRepository.FindByIdAsync(WritesId);
        }
    }
}
