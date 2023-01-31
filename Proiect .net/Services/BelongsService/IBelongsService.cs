using Proiect_.net.Models;
using Proiect_.net.Models.DTOs.Belong;

namespace Proiect_.net.Services.BelongsService
{
    public interface IBelongsService
    {
        public Task CreateBelongs(Guid BookId, Guid CategoryId);
        public Task DeleteBelonbgsById(Guid BelongsId);
        public Task<IEnumerable<BelongsResponseDTO>> GetAllBelongs();
        public Task<BelongsResponseDTO?> GetBelongsById(Guid BelongsId);
    }
}
