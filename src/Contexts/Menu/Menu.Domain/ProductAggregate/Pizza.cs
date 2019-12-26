using System.Collections.Generic;

namespace Menu.Domain.ProductAggregate
{
    public class Pizza : Product
    {
        public override ProductType Type => ProductType.Pizza;

        public CrustType CrustType { get; private set; }

        private List<PizzaIngredient> _ingredients;

        public IReadOnlyList<PizzaIngredient> Ingredients => _ingredients;
        
        public Pizza(string name, string description, float unitPrice, int availableQuantity,
            CrustType crustType) : base(name, description, ProductType.Pizza, unitPrice, availableQuantity)
        {
            CrustType = crustType;
            _ingredients = new List<PizzaIngredient>();
        }

        private Pizza() { }

        public void AddIngredient(Ingredient ingredient)
        {
            var pizzaIngredient = new PizzaIngredient(this, ingredient);
            _ingredients.Add(pizzaIngredient);
        }

        public void ReplaceIngredients(IEnumerable<Ingredient> newIngredients)
        {
            _ingredients.Clear();
            foreach (var ingredient in newIngredients)
            {
               AddIngredient(ingredient);
            }
        }

        public void SetCrustType(CrustType crustType)
        {
            CrustType = crustType;
        }
    }
}
