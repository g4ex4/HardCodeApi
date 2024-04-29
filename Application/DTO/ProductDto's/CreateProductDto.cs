using Application.Common.Mappings;
using Application.DTO.CategoryDto_s;
using Application.DTO.CategoryFIeldDto_s;
using AutoMapper;
using Domain;

namespace Application.DTO.ProductDto_s
{
    public class CreateProductDto : IMapWith<Product>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public List<CategoryFieldDto> CategoryFieldsDto { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductDto, Product>()
                .ForMember(product => product.Name,
                    opt => opt.MapFrom(dto => dto.Name))
                .ForMember(product => product.Description,
                    opt => opt.MapFrom(dto => dto.Description))
                .ForMember(product => product.Price,
                    opt => opt.MapFrom(dto => dto.Price))
                .ForMember(product => product.CategoryId,
                    opt => opt.MapFrom(dto => dto.CategoryId))
                .ReverseMap();
        }
    }
}
