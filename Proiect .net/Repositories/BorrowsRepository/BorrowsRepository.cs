using Proiect_.net.DataBase;
using Proiect_.net.Models;
using Proiect_.net.Repositories.GenericRepository;

namespace Proiect_.net.Repositories.BorrowsRepository
{
    public class BorrowsRepository : GenericRepository<Borrows>, IBorrowsRepository
    {
        public BorrowsRepository(DataBaseContext context) : base(context) { }
      
    }
}
