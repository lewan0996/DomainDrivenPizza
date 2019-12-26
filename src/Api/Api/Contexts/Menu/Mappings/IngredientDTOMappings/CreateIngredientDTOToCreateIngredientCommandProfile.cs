using API.Contexts.Menu.DTO.IngredientDTO;
using AutoMapper;
using Menu.Application.IngredientApplications.CreateIngredientApplication;
using Menu.Domain.ProductAggregate;

#pragma warning disable 1591

namespace API.Contexts.Menu.Mappings.IngredientDTOMappings
{
    public class CreateIngredientDTOToCreateIngredientCommandProfile : Profile
    {
        public CreateIngredientDTOToCreateIngredientCommandProfile()
        {
            var map = CreateMap<CreateIngredientDTO, CreateIngredientCommand>();
            map.ForMember(cmd => cmd.Name, opts => opts.MapFrom(dto => new ProductName(dto.Name)));
            map.ForMember(cmd => cmd.Description, opts => opts.MapFrom(dto => new ProductName(dto.Description)));
        }
    }
}
