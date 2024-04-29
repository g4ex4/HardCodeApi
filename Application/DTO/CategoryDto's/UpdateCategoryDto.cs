using Application.Common.Mappings;
using Application.DTO.CategoryFIeldDto_s;
using AutoMapper;
using Domain;

namespace Application.DTO.CategoryDto_s
{
    public class UpdateCategoryDto : IMapWith<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CategoryFieldDto>? CategoryFields { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCategoryDto, Category>()
                .ForMember(category => category.Name,
                    opt => opt.MapFrom(dto => dto.Name))
                .ForMember(category => category.CategoryFields,
                    opt => opt.MapFrom(dto => dto.CategoryFields))
                .ReverseMap();
        }
    }
}
