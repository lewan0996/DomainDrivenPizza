using Api.Menu.DTO;
using Application.Menu.Commands;
using AutoMapper;
using Domain.Menu.ProductAggregate;

#pragma warning disable 1591

namespace Api.Menu.Mappings.PizzaDTO
{
    public class CreatePizzaDTOToCreatePizzaCommand : Profile
    {
        public CreatePizzaDTOToCreatePizzaCommand()
        {
            var map = CreateMap<CreatePizzaDTO, CreatePizzaCommand>();
            map.ForMember(cmd => cmd.Name, opts => opts.MapFrom(dto => new ProductName(dto.Name)));
            map.ForMember(cmd => cmd.Description, opts => opts.MapFrom(dto => new ProductName(dto.Description)));
        }
    }
}
