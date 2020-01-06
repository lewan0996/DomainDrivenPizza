#pragma warning disable 1591
using AutoMapper;
using Menu.Application.ProductApplications.UpdateProductApplication;
using Menu.Domain.ProductAggregate;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace API.Contexts.Menu.DTO.ProductDTO
{
    [AutoMap(typeof(UpdateProductCommand), ReverseMap = true)]
    public class UpdateProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float? UnitPrice { get; set; }
        public int? AvailableQuantity { get; set; }
        public ProductType? Type { get; set; }
    }
}
