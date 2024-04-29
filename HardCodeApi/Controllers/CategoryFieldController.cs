using Application.DTO.CategoryFIeldDto_s;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HardCodeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryFieldController : ControllerBase
    {
        private readonly CategoryFieldService _categoryFieldService;
        public CategoryFieldController(CategoryFieldService categoryFieldService)
        {
            _categoryFieldService = categoryFieldService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryField(CategoryFieldDto dto)
        {
            return Ok(await _categoryFieldService.CreateCategoryField(dto));
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesFieldByCategoryId(int categoryId)
        {
            return Ok(await _categoryFieldService.GetCategoryFieldsByCategoryId(categoryId));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategoryField(UpdateCategoryFieldDto dto)
        {
            return Ok(await _categoryFieldService.UpdateCategoryFieldAsync(dto));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategoryField(int categoryFiedId)
        {
            return Ok(await _categoryFieldService.DeleteCategoryFieldAsync(categoryFiedId));
        }
    }
}
