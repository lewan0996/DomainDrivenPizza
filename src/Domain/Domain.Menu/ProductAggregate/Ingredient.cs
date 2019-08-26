// ReSharper disable ConvertToAutoProperty
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable ConvertToAutoPropertyWithPrivateSetter
#pragma warning disable IDE0044 // AddAsync readonly modifier
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

        // ReSharper disable once UnusedMember.Global
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

        public void SetSpiciness(bool isSpicy)
        {
            _isSpicy = isSpicy;
        }

        public void SetVegetarianism(bool isVegetarian)
        {
            _isVegetarian = isVegetarian;
        }

        public void SetVegan(bool isVegan)
        {
            _isVegan = isVegan;
        }
    }
}
