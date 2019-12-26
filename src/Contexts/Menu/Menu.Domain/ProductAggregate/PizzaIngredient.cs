namespace Menu.Domain.ProductAggregate
{
    public class PizzaIngredient //todo encapsulate
    {
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        
        public PizzaIngredient(Pizza pizza, Ingredient ingredient)
        {
            Pizza = pizza;
            Ingredient = ingredient;
        }

        private PizzaIngredient() { }
    }
}
