using API.Contexts.Menu.DTO.ProductDTO;
using AutoMapper;
using Menu.Application.ProductApplications.UpdateProductApplication;
using Menu.Domain.ProductAggregate;

#pragma warning disable 1591

namespace API.Contexts.Menu.Mappings.ProductDTOMappings
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
