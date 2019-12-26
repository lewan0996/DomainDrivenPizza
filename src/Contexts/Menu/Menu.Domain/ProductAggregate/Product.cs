using System;
using Shared.Domain;

namespace Menu.Domain.ProductAggregate
{
    public class Product : AggregateRoot
    {
        public ProductName Name { get; private set; }

        public ProductDescription Description { get; private set; }

        public virtual ProductType Type { get; private set; }

        public float UnitPrice { get; private set; }

        public int AvailableQuantity { get; private set; }

        public Product(string name, string description, ProductType type, float unitPrice,
            int availableQuantity = 0)
        {
            Name = new ProductName(name);
            Description = new ProductDescription(description);
            Type = type;
            UnitPrice = unitPrice;
            AvailableQuantity = availableQuantity;
        }

        protected Product() { }

        public void AddToWarehouse(int quantity)
        {
            if (quantity <= 0)
            {
                throw new DomainException(new ArgumentException("The quantity of the product must be greater than 0",
                    nameof(quantity)));
            }

            AvailableQuantity += quantity;
        }

        public void TakeFromWarehouse(int quantity)
        {
            if (quantity <= 0)
            {
                throw new DomainException(new ArgumentException("The quantity of the product must be greater than 0",
                    nameof(quantity)));
            }
            AvailableQuantity -= quantity;
        }

        public void SetName(string name)
        {
            Name = new ProductName(name);
        }

        public void SetDescription(string description)
        {
            Description = new ProductDescription(description);
        }

        public void SetUnitPrice(float unitPrice)
        {
            UnitPrice = unitPrice;
        }

        public void SetType(ProductType type)
        {
            if (type == ProductType.Pizza || type == ProductType.Ingredient)
            {
                throw new DomainException(new ArgumentOutOfRangeException(nameof(type)));
            }

            Type = type;
        }
    }
}
