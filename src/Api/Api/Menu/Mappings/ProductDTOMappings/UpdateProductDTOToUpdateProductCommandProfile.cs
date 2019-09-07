using Api.Menu.DTO.ProductDTO;
using Application.Menu.Commands.ProductCommands;
using AutoMapper;
using Domain.Menu.ProductAggregate;

#pragma warning disable 1591

namespace Api.Menu.Mappings.ProductDTOMappings
{
    public class UpdateProductDTOToUpdateProductCommandProfile : Profile
    {
        public UpdateProductDTOToUpdateProductCommandProfile()
        {
            var map = CreateMap<UpdateProductDTO, UpdateProductCommand>();
            map.ForMember(cmd => cmd.Name, opts => opts.MapFrom(dto => new ProductName(dto.Name)));
            map.ForMember(cmd => cmd.Description, opts => opts.MapFrom(dto => new ProductDescription(dto.Description)));
        }
    }
}
