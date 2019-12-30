#pragma warning disable 1591
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace API.Contexts.Menu.DTO.PizzaDTO
{
    public class CreatePizzaDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float UnitPrice { get; set; }
        public int[] IngredientIds { get; set; }
    }
}
