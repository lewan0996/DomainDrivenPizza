using AutoMapper;
using Menu.Application.Queries.DTO;
using Menu.Domain.ProductAggregate;

#pragma warning disable 1591

namespace API.Contexts.Menu.Mappings.IngredientDTOMappings
{
    public class IngredientToIngredientDTOProfile : Profile
    {
        public IngredientToIngredientDTOProfile()
        {
            var map = CreateMap<Ingredient, IngredientDTO>();
            map.ForMember(dto => dto.Name, opts => opts.MapFrom(i => i.Name.Value));
            map.ForMember(dto => dto.Description, opts => opts.MapFrom(i => i.Description.Value));
        }
    }
}
