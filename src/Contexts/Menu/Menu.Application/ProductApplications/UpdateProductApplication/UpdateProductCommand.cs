using MediatR;
using Menu.Domain.ProductAggregate;

namespace Menu.Application.ProductApplications.UpdateProductApplication
{
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public float? UnitPrice { get; }
        public int? AvailableQuantity { get; }
        public ProductType? Type { get; }

        public UpdateProductCommand(int id, string name, string description, float unitPrice, int availableQuantity,
            ProductType type)
        {
            Id = id;
            Name = name;
            Description = description;
            UnitPrice = unitPrice;
            AvailableQuantity = availableQuantity;
            Type = type;
        }
    }
}
