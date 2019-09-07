using Application.Menu.Queries.DTO;
using AutoMapper;
using Domain.Menu.ProductAggregate;

#pragma warning disable 1591

namespace Api.Menu.Mappings.ProductDTOMappings
{
    public class ProductToProductDTOProfile : Profile
    {
        public ProductToProductDTOProfile()
        {
            var map = CreateMap<Product, ProductDTO>();
            map.ForMember(dto => dto.Name, opts => opts.MapFrom(i => i.Name.Value));
            map.ForMember(dto => dto.Description, opts => opts.MapFrom(i => i.Description.Value));
        }
    }
}
