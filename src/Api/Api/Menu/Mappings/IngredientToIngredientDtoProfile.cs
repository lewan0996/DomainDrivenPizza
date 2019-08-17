using Application.Menu.Queries.DTO;
using AutoMapper;
using Domain.Menu.ProductAggregate;

namespace Api.Menu.Mappings
{
    public class IngredientToIngredientDtoProfile : Profile
    {
        public IngredientToIngredientDtoProfile()
        {
            var map = CreateMap<Ingredient, IngredientDto>();
            map.ForMember(dto => dto.Name, opts => opts.MapFrom(i => i.Name.Value));
            map.ForMember(dto => dto.Description, opts => opts.MapFrom(i => i.Description.Value));
        }
    }
}
