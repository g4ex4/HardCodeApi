using Application.DTO.CategoryDto_s;
using Application.DTO.ProductDto_s;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HardCodeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            return Ok(await _productService.CreateProductAsync(dto));
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById(int productId)
        {
            return Ok(await _productService.GetProductById(productId));
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _productService.GetProducts());
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            return Ok(await _productService.DeleteProduct(productId));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto dto)
        {
            return Ok(await _productService.UpdateProductAsync(dto));
        }
    }
}
