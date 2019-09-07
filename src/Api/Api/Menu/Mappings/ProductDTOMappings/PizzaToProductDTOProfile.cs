using Application.Menu.Queries.DTO;
using AutoMapper;
using Domain.Menu.ProductAggregate;

#pragma warning disable 1591

namespace Api.Menu.Mappings.ProductDTOMappings
{
    public class PizzaToProductDTOProfile : Profile
    {
        public PizzaToProductDTOProfile()
        {
            var map = CreateMap<Pizza, ProductDTO>();
            map.ForMember(p => p.Name, opts => opts.MapFrom(p => p.Name.Value));
            map.ForMember(p => p.Description, opts => opts.MapFrom(p => p.Description.Value));
        }
    }
}
