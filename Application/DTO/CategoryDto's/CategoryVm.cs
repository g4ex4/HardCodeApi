using Application.Common.Mappings;
using Application.DTO.CategoryFIeldDto_s;
using AutoMapper;
using Domain;

namespace Application.DTO.CategoryDto_s
{
    public class CategoryVm : IMapWith<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CategoryFieldDto>? CategoryFields { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CategoryVm, Category>()
                .ForMember(category => category.Id,
                    opt => opt.MapFrom(vm => vm.Id))
                .ForMember(category => category.Name,
                    opt => opt.MapFrom(vm => vm.Name))
                .ForMember(category => category.CategoryFields,
                    opt => opt.MapFrom(vm => vm.CategoryFields))
                .ReverseMap();
        }
    }
}
