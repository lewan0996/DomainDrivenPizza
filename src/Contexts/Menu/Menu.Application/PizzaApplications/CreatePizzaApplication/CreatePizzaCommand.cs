using MediatR;
using Menu.Application.Queries.DTO;

namespace Menu.Application.PizzaApplications.CreatePizzaApplication
{
    public class CreatePizzaCommand : IRequest<PizzaDTO>
    {
        public string Name { get; }
        public string Description { get; }
        public float UnitPrice { get; }
        public int[] IngredientIds { get; }

        public CreatePizzaCommand(string name, string description, float unitPrice, int[] ingredientIds)
        {
            Name = name;
            Description = description;
            UnitPrice = unitPrice;
            IngredientIds = ingredientIds;
        }
    }
}
