#pragma warning disable 1591
using Menu.Domain.ProductAggregate;

namespace API.Contexts.Menu.DTO.ProductDTO
{
    public class CreateProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float UnitPrice { get; set; }
        public int  AvailableQuantity { get; set; }
        public ProductType Type { get; set; }
    }
}
