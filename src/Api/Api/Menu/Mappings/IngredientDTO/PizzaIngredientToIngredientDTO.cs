using AutoMapper;
using Domain.Menu.ProductAggregate;

#pragma warning disable 1591
namespace Api.Menu.Mappings.IngredientDTO
{
    public class PizzaIngredientToIngredientDTO : Profile
    {
        public PizzaIngredientToIngredientDTO()
        {
            var map = CreateMap<PizzaIngredient, Application.Menu.Queries.DTO.IngredientDTO>();
            map.ConstructUsing((pi, ctx) => 
                ctx.Mapper.Map<Application.Menu.Queries.DTO.IngredientDTO>(pi.Ingredient));
        }
    }
}
