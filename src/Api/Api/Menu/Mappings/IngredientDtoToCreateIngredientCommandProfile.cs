using Application.Menu.Commands;
using Application.Menu.Queries.DTO;
using AutoMapper;
using Domain.Menu.ProductAggregate;

namespace Api.Menu.Mappings
{
    public class IngredientDtoToCreateIngredientCommandProfile : Profile
    {
        public IngredientDtoToCreateIngredientCommandProfile()
        {
            var map = CreateMap<IngredientDto, CreateIngredientCommand>();
            map.ForMember(cmd => cmd.Name, opts => opts.MapFrom(dto => new ProductName(dto.Name)));
            map.ForMember(cmd => cmd.Description, opts => opts.MapFrom(dto => new ProductName(dto.Description)));
        }
    }
}
