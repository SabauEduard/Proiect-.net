using Proiect_.net.Models;
using Proiect_.net.Models.DTOs.Categories;
using Proiect_.net.Repositories.UnitOfWork;

namespace Proiect_.net.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateCategory(string Name)
        {
            var category = new Category() { Name = Name };
            await _unitOfWork.categoryRepository.CreateAsync(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteCategoryById(Guid CategoryId)
        {
            var category = await _unitOfWork.categoryRepository.FindByIdAsync(CategoryId);
            if (category == null)
                return;
            _unitOfWork.categoryRepository.Delete(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<CategoryResponseDTO>> GetAllCategories()
        {
            var categories = await _unitOfWork.categoryRepository.GetAllAsync();
            return categories.ConvertAll(c => new CategoryResponseDTO(c));
        }       

        public async Task<CategoryResponseDTO> GetCategoryById(Guid CategoryId)
        {
            var category = await _unitOfWork.categoryRepository.FindByIdAsync(CategoryId);
            return new CategoryResponseDTO(category);
        }
    }
}
