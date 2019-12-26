using API.Contexts.Menu.DTO.IngredientDTO;
using AutoMapper;
using Menu.Application.IngredientApplications.UpdateIngredientApplication;
using Menu.Domain.ProductAggregate;

#pragma warning disable 1591

namespace API.Contexts.Menu.Mappings.IngredientDTOMappings
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
