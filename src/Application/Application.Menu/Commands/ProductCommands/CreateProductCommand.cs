using Application.Menu.Queries.DTO;
using Domain.Menu.ProductAggregate;
using MediatR;

namespace Application.Menu.Commands.ProductCommands
{
    public class CreateProductCommand : IRequest<ProductDTO>
    {
        public string Name { get; }
        public string Description { get; }
        public float UnitPrice { get; }
        public int AvailableQuantity { get; }
        public ProductType Type { get; }

        public CreateProductCommand(string name, string description, float unitPrice, int availableQuantity,
            ProductType type)
        {
            Name = name;
            Description = description;
            UnitPrice = unitPrice;
            AvailableQuantity = availableQuantity;
            Type = type;
        }
    }
}
