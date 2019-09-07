using AutoMapper;
using Domain.Menu.ProductAggregate;

#pragma warning disable 1591

namespace Api.Menu.Mappings.IngredientDTOMappings
{
    public class IngredientToIngredientDTOProfile : Profile
    {
        public IngredientToIngredientDTOProfile()
        {
            var map = CreateMap<Ingredient, Application.Menu.Queries.DTO.IngredientDTO>();
            map.ForMember(dto => dto.Name, opts => opts.MapFrom(i => i.Name.Value));
            map.ForMember(dto => dto.Description, opts => opts.MapFrom(i => i.Description.Value));
        }
    }
}
