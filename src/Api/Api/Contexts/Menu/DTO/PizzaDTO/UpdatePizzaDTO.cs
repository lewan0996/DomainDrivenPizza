#pragma warning disable 1591

using Menu.Domain.ProductAggregate;

namespace API.Contexts.Menu.DTO.PizzaDTO
{
    public class UpdatePizzaDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float? UnitPrice { get; set; }
        public int? AvailableQuantity { get; set; }
        public CrustType? CrustType { get; set; }
        public int[] IngredientIds { get; set; }
    }
}
