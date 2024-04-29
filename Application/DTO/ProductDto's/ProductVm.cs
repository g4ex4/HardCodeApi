using Application.Common.Mappings;
using Application.DTO.CategoryDto_s;
using Application.DTO.CategoryFIeldDto_s;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.ProductDto_s
{
    public class ProductVm : IMapWith<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public CategoryVm Category { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductVm, Product>()
                .ForMember(product => product.Id,
                    opt => opt.MapFrom(dto => dto.Id))
                .ForMember(product => product.Name,
                    opt => opt.MapFrom(dto => dto.Name))
                .ForMember(product => product.Description,
                    opt => opt.MapFrom(dto => dto.Description))
                .ForMember(product => product.Price,
                    opt => opt.MapFrom(dto => dto.Price))
                .ForMember(product => product.Category,
                    opt => opt.MapFrom(dto => dto.Category))
                .ReverseMap();
        }
    }
}
