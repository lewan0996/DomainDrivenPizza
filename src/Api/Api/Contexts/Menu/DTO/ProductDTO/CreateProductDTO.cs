#pragma warning disable 1591
using AutoMapper;
using Menu.Application.ProductApplications.CreateProductApplication;
using Menu.Domain.ProductAggregate;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace API.Contexts.Menu.DTO.ProductDTO
{
    [AutoMap(typeof(CreateProductCommand), ReverseMap = true)]
    public class CreateProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float UnitPrice { get; set; }
        public int AvailableQuantity { get; set; }
        public ProductType Type { get; set; }
    }
}
