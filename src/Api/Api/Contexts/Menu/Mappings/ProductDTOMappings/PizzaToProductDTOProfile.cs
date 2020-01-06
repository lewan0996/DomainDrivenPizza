using AutoMapper;
using Menu.Application.Queries.DTO;
using Menu.Domain.ProductAggregate;

#pragma warning disable 1591

namespace API.Contexts.Menu.Mappings.ProductDTOMappings
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
