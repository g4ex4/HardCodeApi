using Application.DTO.CategoryDto_s;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HardCodeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDto dto)
        {
            return Ok(await _categoryService.CreateCategoryAsync(dto));
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            return Ok(await _categoryService.GetCategoryById(categoryId));
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _categoryService.GetCategories());
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteCategory(string categoryName)
        {
            return Ok(await _categoryService.DeleteCategoryAsync(categoryName));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto dto)
        {
            return Ok(await _categoryService.UpdateCategoryAsync(dto));
        }
    }
}
