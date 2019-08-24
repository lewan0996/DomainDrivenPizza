using System;
using Domain.SharedKernel;

namespace Domain.Menu.ProductAggregate
{
    public class Product : AggregateRoot
    {
        private ProductName _name;
        public ProductName Name => _name;

        private ProductDescription _description;
        public ProductDescription Description => _description;

        private ProductType _type;
        public virtual ProductType Type => _type;

        private float _unitPrice;
        public float UnitPrice => _unitPrice;

        private int _availableQuantity;
        public int AvailableQuantity => _availableQuantity;

        protected Product() { }

        public Product(ProductName name, ProductDescription description, ProductType type, float unitPrice,
            int availableQuantity = 0)
        {
            _name = name;
            _description = description;
            _type = type;
            _unitPrice = unitPrice;
            _availableQuantity = availableQuantity;
        }

        public void AddToWarehouse(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("The quantity of the product must be greater than 0", nameof(quantity));
            }
            
            _availableQuantity += quantity;
        }

        public void TakeFromWarehouse(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("The quantity of the product must be greater than 0", nameof(quantity));
            }
            _availableQuantity -= quantity;
        }
    }
}
