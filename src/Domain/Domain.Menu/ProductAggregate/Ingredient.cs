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

        public Ingredient()
        {
        }
    }
}
