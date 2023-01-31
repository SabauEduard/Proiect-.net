using Proiect_.net.Models;
using Proiect_.net.Models.DTOs.Categories;

namespace Proiect_.net.Services.CategoryService
{
    public interface ICategoryService
    {
        public Task CreateCategory(string Name);
        public Task DeleteCategoryById(Guid CategoryId);
        public Task<CategoryResponseDTO?> GetCategoryById(Guid CategoryId);
        public Task<IEnumerable<CategoryResponseDTO>> GetAllCategories();       
    }
}
