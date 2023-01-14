using Proiect_.net.Models;
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

        public async Task DeleteCategory(Guid CategoryId)
        {
            var category = await _unitOfWork.categoryRepository.FindByIdAsync(CategoryId);
            if (category == null)
                return;
            _unitOfWork.categoryRepository.Delete(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _unitOfWork.categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetCategory(Guid CategoryId)
        {
            return await _unitOfWork.categoryRepository.FindByIdAsync(CategoryId);
        }
    }
}
