// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local
namespace Menu.Domain.ProductAggregate
{
    public class PizzaIngredient
    {
        public int PizzaId { get; private set; }
        public Pizza Pizza { get; private set; }
        public int IngredientId { get; private set; }
        public Ingredient Ingredient { get; private set; }
        
        public PizzaIngredient(Pizza pizza, Ingredient ingredient)
        {
            Pizza = pizza;
            Ingredient = ingredient;
        }

        // ReSharper disable once UnusedMember.Local
        private PizzaIngredient() { } // For EF
    }
}
