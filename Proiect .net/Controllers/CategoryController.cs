using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect_.net.Helpers.Attributes;
using Proiect_.net.Models.DTOs.Categories;
using Proiect_.net.Models.Enums;
using Proiect_.net.Services.CategoryService;

namespace Proiect_.net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [Authorization(Role.Admin)]
        public async Task<IActionResult> AddCategory(CategoryRequestDTO newCategory)
        {
            await _categoryService.CreateCategory(newCategory.Name);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorization(Role.Admin)]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            await _categoryService.DeleteCategoryById(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        [Authorization(Role.Admin, Role.User)]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            var category = await _categoryService.GetCategoryById(id);
            return category is null ? NotFound() : Ok(category);
        }

        [HttpGet]
        [Authorization(Role.Admin, Role.User)]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _categoryService.GetAllCategories());
        }
    }
}
