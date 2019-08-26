using Application.Menu.Queries.DTO;
using MediatR;

namespace Application.Menu.Commands
{
    public class CreateProductCommand : IRequest<ProductDTO>
    {
        public string Name { get; }
        public string Description { get; }
        public float UnitPrice { get; }
        public int AvailableQuantity { get; }

        public CreateProductCommand(string name, string description, float unitPrice, int availableQuantity)
        {
            Name = name;
            Description = description;
            UnitPrice = unitPrice;
            AvailableQuantity = availableQuantity;
        }
    }
}
