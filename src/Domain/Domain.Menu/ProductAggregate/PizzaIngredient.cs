namespace Domain.Menu.ProductAggregate
{
    public class PizzaIngredient //todo encapsulate
    {
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        public PizzaIngredient()
        {
        }

        public PizzaIngredient(Pizza pizza, Ingredient ingredient)
        {
            Pizza = pizza;
            Ingredient = ingredient;
        }
    }
}
