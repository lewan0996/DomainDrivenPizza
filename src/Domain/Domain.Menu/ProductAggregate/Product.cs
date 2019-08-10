using System;
using System.Diagnostics.Contracts;
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
            Contract.Requires<ArgumentException>(quantity > 0);
            _availableQuantity += quantity;
        }

        public void TakeFromWarehouse(int quantity)
        {
            Contract.Requires<ArgumentException>(quantity > 0);
            _availableQuantity -= quantity;
        }
    }
}
