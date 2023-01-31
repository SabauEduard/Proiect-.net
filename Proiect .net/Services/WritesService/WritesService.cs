using Proiect_.net.Models;
using Proiect_.net.Models.DTOs.Write;
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
            var writes = new Writes() { Id = Guid.NewGuid(), AuthorId = AuthorId, BookId = BookId };
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

        public async Task<IEnumerable<WritesResponseDTO>> GetAllWrites()
        {
            var writes = await _unitOfWork.writesRepository.GetAllAsync();
            return writes.ConvertAll(w => new WritesResponseDTO(w));
        }

        public async Task<WritesResponseDTO?> GetWritesById(Guid WritesId)
        {
            var writes = await _unitOfWork.writesRepository.FindByIdAsync(WritesId);
            return new WritesResponseDTO(writes);
        }
    }
}
