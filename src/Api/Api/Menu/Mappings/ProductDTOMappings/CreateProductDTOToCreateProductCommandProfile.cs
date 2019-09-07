using Api.Menu.DTO.ProductDTO;
using Application.Menu.Commands.ProductCommands;
using AutoMapper;
using Domain.Menu.ProductAggregate;

#pragma warning disable 1591

namespace Api.Menu.Mappings.ProductDTOMappings
{
    public class CreateProductDTOToCreateProductCommandProfile : Profile
    {
        public CreateProductDTOToCreateProductCommandProfile()
        {
            var map = CreateMap<CreateProductDTO, CreateProductCommand>();
            map.ForMember(cmd => cmd.Name, opts => opts.MapFrom(dto => new ProductName(dto.Name)));
            map.ForMember(cmd => cmd.Description, opts => opts.MapFrom(dto => new ProductDescription(dto.Description)));
        }
    }
}
