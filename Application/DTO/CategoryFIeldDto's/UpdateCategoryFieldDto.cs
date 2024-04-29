using Application.Common.Mappings;
using AutoMapper;
using Domain;

namespace Application.DTO.CategoryFIeldDto_s
{
    public class UpdateCategoryFieldDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int CategoryId { get; set; }
    }
}
