using MediatR;

namespace Application.Menu.Commands
{
    public class UpdateIngredientCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; }
        public string Description { get; }
        public float? UnitPrice { get; }
        public int? AvailableQuantity { get; }
        public bool? IsSpicy { get; }
        public bool? IsVegetarian { get; }
        public bool? IsVegan { get; }

        public UpdateIngredientCommand(int id, string name, string description, float? unitPrice, int? availableQuantity,
            bool? isSpicy, bool? isVegetarian, bool? isVegan)
        {
            Id = id;
            IsSpicy = isSpicy;
            IsVegetarian = isVegetarian;
            IsVegan = isVegan;
            Name = name;
            Description = description;
            UnitPrice = unitPrice;
            AvailableQuantity = availableQuantity;
        }
    }
}
