using Domain.Menu.ProductAggregate;

#pragma warning disable 1591
namespace Api.Menu.DTO.ProductDTO
{
    public class UpdateProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float? UnitPrice { get; set; }
        public int? AvailableQuantity { get; set; }
        public ProductType? Type { get; set; }
    }
}
