using Proiect_.net.Models;
using Proiect_.net.Models.DTOs.Borrow;

namespace Proiect_.net.Services.BorrowsService
{
    public interface IBorrowsService
    {
        public Task CreateBorrows(Guid BookId, Guid UserId);
        public Task DeleteBorrowsById(Guid BorrowsId);
        public Task<BorrowsResponseDTO?> GetBorrowsById(Guid BorrowsId);
        public Task<IEnumerable<BorrowsResponseDTO>> GetAllBorrows();
    }
}
