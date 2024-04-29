using Application.DTO.CategoryDto_s;

namespace Application.DTO.ProductDto_s
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public UpdateCategoryDto? Category { get; set; }
    }
}
