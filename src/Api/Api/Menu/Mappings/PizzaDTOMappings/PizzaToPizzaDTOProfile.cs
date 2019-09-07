using AutoMapper;
using Domain.Menu.ProductAggregate;

#pragma warning disable 1591

namespace Api.Menu.Mappings.PizzaDTOMappings
{
    //todo Inherit Product profile
    public class PizzaToPizzaDTOProfile : Profile
    {
        public PizzaToPizzaDTOProfile()
        {
            var map = CreateMap<Pizza, Application.Menu.Queries.DTO.PizzaDTO>();
            map.ForMember(dto => dto.Name, opts => opts.MapFrom(i => i.Name.Value));
            map.ForMember(dto => dto.Description, opts => opts.MapFrom(i => i.Description.Value));
        }
    }
}
