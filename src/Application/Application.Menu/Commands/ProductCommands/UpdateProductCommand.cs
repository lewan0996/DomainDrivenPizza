using Domain.Menu.ProductAggregate;
using MediatR;

namespace Application.Menu.Commands.ProductCommands
{
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; }
        public string Description { get; }
        public float? UnitPrice { get; }
        public int? AvailableQuantity { get; }
        public ProductType? Type { get; }

        public UpdateProductCommand(string name, string description, float? unitPrice, int? availableQuantity,
            ProductType? type)
        {
            Name = name;
            Description = description;
            UnitPrice = unitPrice;
            AvailableQuantity = availableQuantity;
            Type = type;
        }
    }
}
