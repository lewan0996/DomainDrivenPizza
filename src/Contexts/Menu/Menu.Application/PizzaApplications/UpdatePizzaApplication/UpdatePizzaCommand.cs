using MediatR;

namespace Menu.Application.PizzaApplications.UpdatePizzaApplication
{
    public class UpdatePizzaCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; }
        public string Description { get; }
        public float? UnitPrice { get; }
        public int? AvailableQuantity { get; }
        public int[] IngredientIds { get; }

        public UpdatePizzaCommand(string name, string description, float? unitPrice, int? availableQuantity,
            int[] ingredientIds)
        {
            Name = name;
            Description = description;
            UnitPrice = unitPrice;
            AvailableQuantity = availableQuantity;
            IngredientIds = ingredientIds;
        }
    }
}
