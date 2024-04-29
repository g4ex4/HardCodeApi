using Application.Common.Exceptions;
using Application.DTO;
using Application.DTO.ProductDto_s;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ProductService
    {
        private readonly IAppDbContext _appDbContext;
        private readonly CategoryService _categoryService;
        private readonly IMapper _mapper;
        public ProductService(IAppDbContext appDbContext, IMapper mapper,
            CategoryService categoryService)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<Result> CreateProductAsync(CreateProductDto dto)
        {
            var product = await _appDbContext.Products
                .FirstOrDefaultAsync(x => x.Name == dto.Name);
            if (product != null) throw new ExistException(nameof(Product), dto.Name);

            var category = await _appDbContext.Categories
                .Include(x => x.CategoryFields)
                .FirstOrDefaultAsync(x => x.Id == dto.CategoryId);
            if (category == null) throw new NotFoundException(nameof(Category), dto.CategoryId);

            product = _mapper.Map<Product>(dto);
            product.Category = category;
            product.Category.CategoryFields =
                _mapper.Map<List<CategoryField>>(dto.CategoryFieldsDto);

            var categoryFields = _mapper.Map<List<CategoryField>>(dto.CategoryFieldsDto);

            await _appDbContext.Products.AddAsync(product);
            await _appDbContext.SaveChangesAsync(CancellationToken.None);

            return new Result(200, "Product created successfully");
        }

        public async Task<ProductVm> GetProductById(int productId)
        {
            var product = await _appDbContext.Products
                .Include(x => x.Category)
                .ThenInclude(x => x.CategoryFields)
                .FirstOrDefaultAsync(x => x.Id == productId);
                
            if (product == null) throw new NotFoundException(nameof(Product), productId);

            return _mapper.Map<ProductVm>(product);
        }

        public async Task<List<ProductVm>> GetProducts()
        {
            var products = await _appDbContext.Products
                .Include(x =>x.Category)
                .ThenInclude(x => x.CategoryFields)
                .ToListAsync();

            return _mapper.Map<List<ProductVm>>(products);
        }

        public async Task<Result> UpdateProductAsync(UpdateProductDto dto)
        {
            var product = await _appDbContext.Products
                .Include(x => x.Category)
                .ThenInclude(x => x.CategoryFields)
                .FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (product == null) throw new NotFoundException(nameof(Product), dto.Id);

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;  
            product.Category.Name = dto.Category?.Name;
            product.Category.CategoryFields =
                _mapper.Map<List<CategoryField>>(dto.Category?.CategoryFields);

            _appDbContext.Products.Update(product);
            await _appDbContext.SaveChangesAsync(CancellationToken.None);

            return new Result<ProductVm>(200, "Product updated successfully",
                _mapper.Map<ProductVm>(product));
        }

        public async Task<Result> DeleteProduct(int id)
        {
            var product = await _appDbContext.Products
                .FindAsync(id);
            if (product == null) throw new NotFoundException(nameof(Product), id);

            _appDbContext.Products.Remove(product);
            await _appDbContext.SaveChangesAsync(CancellationToken.None);
            return new Result(200, "Product deleted successfully!");
        }
    }
}
