using Proiect_.net.DataBase;
using Proiect_.net.Models;
using Proiect_.net.Repositories.GenericRepository;

namespace Proiect_.net.Repositories.CategoryRepository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataBaseContext context) : base(context) { }
       
        public Category FindByName(string Name)
        {
            return _table.FirstOrDefault(c => c.Name == Name);
        }
    }
}
