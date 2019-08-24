using System.Collections.Generic;

namespace Domain.Menu.ProductAggregate
{
    public class Pizza : Product
    {
        public override ProductType Type => ProductType.Pizza;

        private CrustType _crustType;
        public CrustType CrustType => _crustType;

        private List<PizzaIngredient> _ingredients;
        public IReadOnlyList<PizzaIngredient> Ingredients => _ingredients;

        public Pizza()
        {
        }
    }
}
