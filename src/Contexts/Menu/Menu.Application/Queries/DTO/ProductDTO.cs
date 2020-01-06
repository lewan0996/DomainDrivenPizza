using Menu.Domain.ProductAggregate;

namespace Menu.Application.Queries.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float UnitPrice { get; set; }
        public int AvailableQuantity { get; set; }
        public ProductType Type { get; set; }
    }
}
