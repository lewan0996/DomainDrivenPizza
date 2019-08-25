using System.Collections.Generic;
// ReSharper disable ConvertToAutoProperty
// ReSharper disable CollectionNeverUpdated.Local
#pragma warning disable 649
#pragma warning disable IDE0044 // Add readonly modifier
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
    }
}
