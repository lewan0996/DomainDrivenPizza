namespace Menu.Domain.ProductAggregate
{
    public class Ingredient : Product
    {
        public bool IsSpicy { get; private set; }

        public bool IsVegetarian { get; private set; }

        public bool IsVegan { get; private set; }

        public override ProductType Type => ProductType.Ingredient;
        
        public Ingredient(string name, string description, float unitPrice, bool isSpicy,
            bool isVegetarian, bool isVegan,
            int availableQuantity = 0) : base(name, description, ProductType.Ingredient, unitPrice, availableQuantity)
        {
            IsSpicy = isSpicy;
            IsVegetarian = isVegetarian;
            IsVegan = isVegan;
        }

        private Ingredient()
        {
            
        }

        public void SetSpiciness(bool isSpicy)
        {
            IsSpicy = isSpicy;
        }

        public void SetVegetarianism(bool isVegetarian)
        {
            IsVegetarian = isVegetarian;
        }

        public void SetVegan(bool isVegan)
        {
            IsVegan = isVegan;
        }
    }
}
