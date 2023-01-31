using Proiect_.net.Repositories.GenericRepository;
using Proiect_.net.Models;

namespace Proiect_.net.Repositories.CategoryRepository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        public Category FindByName(string Name);       
    }
}
