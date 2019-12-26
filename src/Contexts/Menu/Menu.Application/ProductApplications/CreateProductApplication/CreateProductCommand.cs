using MediatR;
using Menu.Application.Queries.DTO;
using Menu.Domain.ProductAggregate;

namespace Menu.Application.ProductApplications.CreateProductApplication
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
