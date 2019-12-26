using AutoMapper;
using Menu.Application.Queries.DTO;
using Menu.Domain.ProductAggregate;

#pragma warning disable 1591
namespace API.Contexts.Menu.Mappings.IngredientDTOMappings
{
    public class PizzaIngredientToIngredientDTO : Profile
    {
        public PizzaIngredientToIngredientDTO()
        {
            var map = CreateMap<PizzaIngredient, IngredientDTO>();
            map.ConstructUsing((pi, ctx) => 
                ctx.Mapper.Map<IngredientDTO>(pi.Ingredient));
        }
    }
}
