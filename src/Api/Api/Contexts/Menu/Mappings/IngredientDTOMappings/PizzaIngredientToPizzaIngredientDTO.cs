using AutoMapper;
using Menu.Application.Queries.DTO;
using Menu.Domain.ProductAggregate;

#pragma warning disable 1591
namespace API.Contexts.Menu.Mappings.IngredientDTOMappings
{
    public class PizzaIngredientToPizzaIngredientDTO : Profile
    {
        public PizzaIngredientToPizzaIngredientDTO()
        {
            var ingredientMap = CreateMap<Ingredient, PizzaIngredientDTO>();
            ingredientMap.ForMember(dto => dto.Name, opts => opts.MapFrom(i => i.Name.Value));
            ingredientMap.ForMember(dto => dto.Description, opts => opts.MapFrom(i => i.Description.Value));
            
            var map = CreateMap<PizzaIngredient, PizzaIngredientDTO>();
            map.ConstructUsing((pi, ctx) =>
                ctx.Mapper.Map<PizzaIngredientDTO>(pi.Ingredient));
        }
    }
}
