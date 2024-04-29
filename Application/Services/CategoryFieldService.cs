using Application.Common.Exceptions;
using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Application.DTO.CategoryFIeldDto_s;

namespace Application.Services
{
    public class CategoryFieldService
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public CategoryFieldService(IAppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<Result> CreateCategoryField(CategoryFieldDto dto)
        {
            var category = await _appDbContext.Categories.FindAsync(dto.CategoryId);
            if (category == null) throw new NotFoundException(nameof(category), dto.CategoryId);

            var categoryField = await _appDbContext.CategoriesField
                .FirstOrDefaultAsync(x => x.CategoryId == dto.CategoryId
                && x.Name == dto.Name);

            if (categoryField != null) throw new ExistException(nameof(CategoryField), dto.Name);

            categoryField = _mapper.Map<CategoryField>(dto);
            await _appDbContext.CategoriesField.AddAsync(categoryField);
            await _appDbContext.SaveChangesAsync(CancellationToken.None);
            return new Result(200, $"Addional field for {category.Name} created successfully!");
        }

        public async Task<List<CategoryFieldDto>> GetCategoryFieldsByCategoryId(int categoryId)
        {
            var categoryFields = _appDbContext.CategoriesField
                .Where(x => x.CategoryId == categoryId)
                .ToList();
            return _mapper.Map<List<CategoryFieldDto>>(categoryFields);
        }

        public async Task<Result> DeleteCategoryFieldAsync(int categoryFieldId)
        {
            var categoryField = await _appDbContext.CategoriesField
                .FindAsync(categoryFieldId);
            if (categoryField == null) throw new NotFoundException(nameof(Category), categoryFieldId);

            _appDbContext.CategoriesField.Remove(categoryField);
            await _appDbContext.SaveChangesAsync(CancellationToken.None);
            return new Result(200, "Addional field deleted successfully!");
        }

        public async Task<Result> UpdateCategoryFieldAsync(UpdateCategoryFieldDto dto)
        {
            var category = await _appDbContext.Categories
                .FindAsync(dto.CategoryId);
            if (category == null) throw new NotFoundException(nameof(Category), dto.CategoryId);

            var categoryField = await _appDbContext.CategoriesField
                .FindAsync(dto.Id);
            if (categoryField == null) throw new NotFoundException(nameof(CategoryField), dto.Id);

            categoryField.Name = dto.Name;
            categoryField.Value = dto.Value;
            
            _appDbContext.CategoriesField.Update(categoryField);
            await _appDbContext.SaveChangesAsync(CancellationToken.None);

            return new Result<UpdateCategoryFieldDto>(200, "Addional field updated successfully",
                _mapper.Map<UpdateCategoryFieldDto>(categoryField));
        }
    }
}
