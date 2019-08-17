namespace Domain.Menu.ProductAggregate
{
    public class Ingredient : Product
    {
        private bool _isSpicy;
        public bool IsSpicy => _isSpicy;

        private bool _isVegetarian;
        public bool IsVegetarian => _isVegetarian;

        private bool _isVegan;
        public bool IsVegan => _isVegan;

        public override ProductType Type => ProductType.Ingredient;

        public Ingredient()
        {
        }

        public Ingredient(ProductName name, ProductDescription description, float unitPrice, bool isSpicy,
            bool isVegetarian, bool isVegan,
            int availableQuantity = 0) : base(name, description, ProductType.Ingredient, unitPrice, availableQuantity)
        {
            _isSpicy = isSpicy;
            _isVegetarian = isVegetarian;
            _isVegan = isVegan;
        }
    }
}
