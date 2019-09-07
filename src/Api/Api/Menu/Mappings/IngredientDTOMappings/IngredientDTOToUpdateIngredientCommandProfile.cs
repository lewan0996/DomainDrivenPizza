using Api.Menu.DTO.IngredientDTO;
using Application.Menu.Commands.IngredientCommands;
using AutoMapper;
using Domain.Menu.ProductAggregate;

#pragma warning disable 1591

namespace Api.Menu.Mappings.IngredientDTOMappings
{
    public class UpdateIngredientDTOToUpdateIngredientCommandProfile : Profile
    {
        public UpdateIngredientDTOToUpdateIngredientCommandProfile()
        {
            var map = CreateMap<UpdateIngredientDTO, UpdateIngredientCommand>();
            map.ForMember(cmd => cmd.Name, opts => opts.MapFrom(dto => new ProductName(dto.Name)));
            map.ForMember(cmd => cmd.Description, opts => opts.MapFrom(dto => new ProductName(dto.Description)));
        }
    }
}
