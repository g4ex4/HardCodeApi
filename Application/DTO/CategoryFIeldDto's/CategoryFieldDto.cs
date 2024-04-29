using Application.Common.Mappings;
using AutoMapper;
using Domain;

namespace Application.DTO.CategoryFIeldDto_s
{
    public class CategoryFieldDto : IMapWith<CategoryField>
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int CategoryId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CategoryFieldDto, CategoryField>()
                .ForMember(field => field.Name,
                    opt => opt.MapFrom(dto => dto.Name))
                .ForMember(field => field.Value,
                    opt => opt.MapFrom(dto => dto.Value))
                .ForMember(field => field.CategoryId,
                    opt => opt.MapFrom(dto => dto.CategoryId))
                .ReverseMap();
        }
    }
}
