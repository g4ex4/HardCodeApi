using Application.DTO.CategoryDto_s;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Domain;
using AutoMapper;
using Application.DTO;
using AutoMapper.QueryableExtensions;

namespace Application.Services
{
    public class CategoryService
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public CategoryService(IAppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<Result> CreateCategoryAsync(CategoryDto dto)
        {
            var existingCategory = await _appDbContext.Categories
                .FirstOrDefaultAsync(x => x.Name == dto.Name);

            if (existingCategory != null) throw new ExistException(nameof(Category), dto.Name);

            Category category = _mapper.Map<Category>(dto);
            await _appDbContext.Categories.AddAsync(category);
            await _appDbContext.SaveChangesAsync(CancellationToken.None);
            return new Result(200, "Category created successfully!");
        }

        public async Task<CategoryVm> GetCategoryById(int categoryId)
        {
            var category = await _appDbContext.Categories
                .Include(x => x.CategoryFields)
                .FirstOrDefaultAsync(x => x.Id == categoryId);
            if (category == null) throw new NotFoundException(nameof(Category), categoryId);

            return _mapper.Map<CategoryVm>(category);
        }

        public async Task<List<CategoryVm>> GetCategories()
        {
            var categories = await _appDbContext.Categories
                .Include(x => x.CategoryFields)
                .ToListAsync();
            return  _mapper.Map<List<CategoryVm>>(categories);
        }

        public async Task<Result> DeleteCategoryAsync(string name)
        {
            var category = await _appDbContext.Categories
                .FirstOrDefaultAsync(x => x.Name == name);
            if (category == null) throw new NotFoundException(nameof(Category), name);
        
            _appDbContext.Categories.Remove(category);
            await _appDbContext.SaveChangesAsync(CancellationToken.None);
            return new Result(200, "Category deleted successfully!");
        }

        public async Task<Result> UpdateCategoryAsync(UpdateCategoryDto dto)
        {
            var category = await _appDbContext.Categories
                .Include(x => x.CategoryFields)
                .FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (category == null) throw new NotFoundException(nameof(Category), dto.Id);

            category.Name = dto.Name;
            category.CategoryFields = _mapper.Map<List<CategoryField>>(dto.CategoryFields);

            _appDbContext.Categories.Update(category);
            await _appDbContext.SaveChangesAsync(CancellationToken.None);

            return new Result<CategoryDto>(200, "Category updated successfully",
                _mapper.Map<CategoryDto>(category));
        }
    }
}
