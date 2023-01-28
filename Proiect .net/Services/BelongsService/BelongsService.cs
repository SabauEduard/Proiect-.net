using Proiect_.net.Models;
using Proiect_.net.Repositories.UnitOfWork;

namespace Proiect_.net.Services.BelongsService
{
    public class BelongsService : IBelongsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BelongsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateBelongs(Guid BookId, Guid CategoryId)
        {
            var belongs = new Belongs() { Id = Guid.NewGuid(), BookId = BookId, CategoryId = CategoryId };
            await _unitOfWork.belongsRepository.CreateAsync(belongs);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteBelonbgsById(Guid BelongsId)
        {
            var belongs = await _unitOfWork.belongsRepository.FindByIdAsync(BelongsId);
            if (belongs is null)
                return;
            _unitOfWork.belongsRepository.Delete(belongs);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<Belongs>> GetAllBelongs()
        {
            return await _unitOfWork.belongsRepository.GetAllAsync();
        }

        public async Task<Belongs?> GetBelongsById(Guid BelongsId)
        {
            return await _unitOfWork.belongsRepository.FindByIdAsync(BelongsId);

        }
    }
}
