using Api.Menu.DTO.PizzaDTO;
using Application.Menu.Commands.PizzaCommands;
using AutoMapper;
using Domain.Menu.ProductAggregate;

#pragma warning disable 1591

namespace Api.Menu.Mappings.PizzaDTOMappings
{
    public class UpdatePizzaDTOToUpdatePizzaCommandProfile : Profile
    {
        public UpdatePizzaDTOToUpdatePizzaCommandProfile()
        {
            var map = CreateMap<UpdatePizzaDTO, UpdatePizzaCommand>();
            map.ForMember(cmd => cmd.Name, opts => opts.MapFrom(dto => new ProductName(dto.Name)));
            map.ForMember(cmd => cmd.Description, opts => opts.MapFrom(dto => new ProductDescription(dto.Description)));
        }
    }
}
