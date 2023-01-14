using Proiect_.net.DataBase;
using Proiect_.net.Models;
using Proiect_.net.Repositories.GenericRepository;

namespace Proiect_.net.Repositories.PenaltyRepository
{
    public class PenaltyRepository : GenericRepository<Penalty>, IPenaltyRepository
    {
        public PenaltyRepository(DataBaseContext context) : base(context) { }    
    }
}
