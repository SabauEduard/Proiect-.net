using Proiect_.net.DataBase;
using Proiect_.net.Models;
using Proiect_.net.Repositories.GenericRepository;

namespace Proiect_.net.Repositories.WritesRepository
{
    public class WritesRepository : GenericRepository<Writes>, IWritesRepository
    {
        public WritesRepository(DataBaseContext context) : base(context) { }      
    }
}
