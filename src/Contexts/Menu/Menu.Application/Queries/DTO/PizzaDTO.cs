using Menu.Domain.ProductAggregate;

namespace Menu.Application.Queries.DTO
{
    public class PizzaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float UnitPrice { get; set; }
        public int AvailableQuantity { get; set; }
        public CrustType CrustType { get; set; }
        public IngredientDTO[] Ingredients { get; set; } //todo All ingredient information such as price and quantity are not needed here
    }
}
