using Proiect_.net.DataBase;
using Proiect_.net.Models;
using Proiect_.net.Repositories.GenericRepository;

namespace Proiect_.net.Repositories.PenaltyReceiptRepository
{
    public class PenaltyReceiptRepository : GenericRepository<PenaltyReceipt>, IPenaltyReceiptRepository
    {
        public PenaltyReceiptRepository(DataBaseContext context) : base(context) { }       
    }
}
