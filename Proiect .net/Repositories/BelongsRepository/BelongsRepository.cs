using Proiect_.net.DataBase;
using Proiect_.net.Models;
using Proiect_.net.Repositories.GenericRepository;

namespace Proiect_.net.Repositories.BelongsRepository
{
    public class BelongsRepository : GenericRepository<Belongs>, IBelongsRepository
    {
        public BelongsRepository(DataBaseContext context) : base(context) { }
    }
}
