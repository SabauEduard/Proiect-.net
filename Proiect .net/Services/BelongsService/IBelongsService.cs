using Proiect_.net.Models;

namespace Proiect_.net.Services.BelongsService
{
    public interface IBelongsService
    {
        public Task CreateBelongs(Guid BookId, Guid CategoryId);
        public Task DeleteBelonbgsById(Guid BelongsId);
        public Task<IEnumerable<Belongs>> GetAllBelongs();
        public Task<Belongs?> GetBelongsById(Guid BelongsId);
    }
}
