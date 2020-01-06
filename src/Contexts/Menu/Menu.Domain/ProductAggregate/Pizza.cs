using System.Collections.Generic;
using System.Linq;

namespace Menu.Domain.ProductAggregate
{
    public class Pizza : Product
    {
        public override ProductType Type => ProductType.Pizza;

        public override int AvailableQuantity => _ingredients.Min(pi => pi.Ingredient.AvailableQuantity);

        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private List<PizzaIngredient> _ingredients;

        public IReadOnlyList<PizzaIngredient> Ingredients => _ingredients;

        public Pizza(string name, string description, float unitPrice) : base(name, description, ProductType.Pizza,
            unitPrice)
        {
            _ingredients = new List<PizzaIngredient>();
        }

        // ReSharper disable once UnusedMember.Local
        private Pizza() { } // For EF

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

        public override void TakeFromWarehouse(int quantity)
        {
            foreach (var pizzaIngredient in _ingredients)
            {
                pizzaIngredient.Ingredient.TakeFromWarehouse(quantity);
            }
        }
    }
}
