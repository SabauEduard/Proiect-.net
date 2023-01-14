using Proiect_.net.Models;

namespace Proiect_.net.Services.CategoryService
{
    public interface ICategoryService
    {
        public Task CreateCategory(string Name);
        public Task DeleteCategoryById(Guid CategoryId);
        public Task<Category> GetCategoryById(Guid CategoryId);
        public Task<IEnumerable<Category>> GetAllCategories();
    }
}
