using API.Contexts.Menu.DTO.PizzaDTO;
using AutoMapper;
using Menu.Application.PizzaApplications.UpdatePizzaApplication;
using Menu.Domain.ProductAggregate;

#pragma warning disable 1591

namespace API.Contexts.Menu.Mappings.PizzaDTOMappings
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
