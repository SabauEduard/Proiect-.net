using Proiect_.net.Models;
using Proiect_.net.Repositories.UnitOfWork;

namespace Proiect_.net.Services.BorrowsService
{
    public class BorrowsService : IBorrowsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BorrowsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateBorrows(Guid BookId, Guid UserId)
        {
            var borrows = new Borrows() { Id = Guid.NewGuid(), BookId = BookId, UserId = UserId };
            await _unitOfWork.borrowsRepository.CreateAsync(borrows);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteBorrowsById(Guid BorrowsId)
        {
            var borrows = await _unitOfWork.borrowsRepository.FindByIdAsync(BorrowsId);
            if (borrows is null)
                return;
            _unitOfWork.borrowsRepository.Delete(borrows);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<Borrows>> GetAllBorrows()
        {
            return await _unitOfWork.borrowsRepository.GetAllAsync();
        }

        public async Task<Borrows?> GetBorrowsById(Guid BorrowsId)
        {
            return await _unitOfWork.borrowsRepository.FindByIdAsync(BorrowsId);
           
        }
    }
}
