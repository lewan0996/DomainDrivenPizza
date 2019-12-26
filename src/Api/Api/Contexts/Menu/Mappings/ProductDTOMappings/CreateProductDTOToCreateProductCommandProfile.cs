using API.Contexts.Menu.DTO.ProductDTO;
using AutoMapper;
using Menu.Application.ProductApplications.CreateProductApplication;
using Menu.Domain.ProductAggregate;

#pragma warning disable 1591

namespace API.Contexts.Menu.Mappings.ProductDTOMappings
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
