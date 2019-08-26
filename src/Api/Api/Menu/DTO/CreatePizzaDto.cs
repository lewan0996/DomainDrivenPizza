using Domain.Menu.ProductAggregate;

#pragma warning disable 1591
namespace Api.Menu.DTO
{
    public class CreatePizzaDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float UnitPrice { get; set; }
        public int AvailableQuantity { get; set; }
        public CrustType CrustType { get; set; }
        public int[] IngredientIds { get; set; }
    }
}
