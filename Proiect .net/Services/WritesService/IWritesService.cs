using Proiect_.net.Models;
using Proiect_.net.Models.DTOs.Write;

namespace Proiect_.net.Services.WritesService
{
    public interface IWritesService
    {
        public Task CreateWrites(Guid AuthorId, Guid BookId);
        public Task DeleteWritesById(Guid WritesId);
        public Task<WritesResponseDTO?> GetWritesById(Guid WritesId);
        public Task<IEnumerable<WritesResponseDTO>> GetAllWrites();
    }
}
