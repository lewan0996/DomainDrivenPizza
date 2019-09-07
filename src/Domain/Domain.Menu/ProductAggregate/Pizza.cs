using System.Collections.Generic;
// ReSharper disable ConvertToAutoProperty
// ReSharper disable CollectionNeverUpdated.Local
#pragma warning disable 649
#pragma warning disable IDE0044 // AddAsync readonly modifier
namespace Domain.Menu.ProductAggregate
{
    public class Pizza : Product
    {
        public override ProductType Type => ProductType.Pizza;

        private CrustType _crustType;
        public CrustType CrustType => _crustType;

        private List<PizzaIngredient> _ingredients;

        public IReadOnlyList<PizzaIngredient> Ingredients => _ingredients;

        // ReSharper disable once EmptyConstructor
        public Pizza()
        {
        }

        public Pizza(ProductName name, ProductDescription description, float unitPrice, int availableQuantity,
            CrustType crustType) : base(name, description, ProductType.Pizza, unitPrice, availableQuantity)
        {
            _crustType = crustType;
            _ingredients = new List<PizzaIngredient>();
        }

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
            _crustType = crustType;
        }
    }
}
