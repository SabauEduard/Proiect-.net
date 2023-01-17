using Proiect_.net.Models;

namespace Proiect_.net.Services.BorrowsService
{
    public interface IBorrowsService
    {
        public Task CreateBorrows(Guid BookId, Guid UserId);
        public Task DeleteBorrowsById(Guid BorrowsId);
        public Task<Borrows?> GetBorrowsById(Guid BorrowsId);
        public Task<IEnumerable<Borrows>> GetAllBorrows();
    }
}
