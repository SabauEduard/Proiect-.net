using Proiect_.net.Models;

namespace Proiect_.net.Services.WritesService
{
    public interface IWritesService
    {
        public Task CreateWrites(Guid AuthorId, Guid BookId);
        public Task DeleteWritesById(Guid WritesId);
        public Task<Writes> GetWritesById(Guid WritesId);
        public Task<IEnumerable<Writes>> GetAllWrites();
    }
}
