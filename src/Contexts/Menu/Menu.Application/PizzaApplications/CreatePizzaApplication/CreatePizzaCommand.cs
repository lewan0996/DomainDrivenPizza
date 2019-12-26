using MediatR;
using Menu.Application.Queries.DTO;
using Menu.Domain.ProductAggregate;

namespace Menu.Application.PizzaApplications.CreatePizzaApplication
{
    public class CreatePizzaCommand: IRequest<PizzaDTO>
    {
        public string Name { get; }
        public string Description { get; }
        public float UnitPrice { get; }
        public int AvailableQuantity { get; }
        public CrustType CrustType { get; }
        public int[] IngredientIds { get; }

        public CreatePizzaCommand(string name, string description, float unitPrice, int availableQuantity, CrustType crustType, int[] ingredientIds)
        {
            Name = name;
            Description = description;
            UnitPrice = unitPrice;
            AvailableQuantity = availableQuantity;
            CrustType = crustType;
            IngredientIds = ingredientIds;
        }
    }
}
