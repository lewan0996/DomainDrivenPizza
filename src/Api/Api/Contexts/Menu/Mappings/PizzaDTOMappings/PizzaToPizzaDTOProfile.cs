using AutoMapper;
using Menu.Application.Queries.DTO;
using Menu.Domain.ProductAggregate;

#pragma warning disable 1591

namespace API.Contexts.Menu.Mappings.PizzaDTOMappings
{
    //todo Inherit Product profile
    public class PizzaToPizzaDTOProfile : Profile
    {
        public PizzaToPizzaDTOProfile()
        {
            var map = CreateMap<Pizza, PizzaDTO>();
            map.ForMember(dto => dto.Name, opts => opts.MapFrom(i => i.Name.Value));
            map.ForMember(dto => dto.Description, opts => opts.MapFrom(i => i.Description.Value));
        }
    }
}
