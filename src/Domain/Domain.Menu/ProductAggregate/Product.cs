using System;
using Domain.SharedKernel;
// ReSharper disable ConvertToAutoPropertyWithPrivateSetter
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable ConvertToAutoProperty
// ReSharper disable ConvertToAutoPropertyWhenPossible
#pragma warning disable IDE0044 // AddAsync readonly modifier
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

        // ReSharper disable once UnusedMember.Global
        protected Product() { }

        public Product(string name, string description, ProductType type, float unitPrice,
            int availableQuantity = 0)
        {
            _name = new ProductName(name);
            _description = new ProductDescription(description);
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

        public void SetName(string name)
        {
            _name = new ProductName(name);
        }

        public void SetDescription(string description)
        {
            _description = new ProductDescription(description);
        }

        public void SetUnitPrice(float unitPrice)
        {
            _unitPrice = unitPrice;
        }

        public void SetType(ProductType type)
        {
            if (type == ProductType.Pizza || type == ProductType.Ingredient)
            {
                throw new ArgumentOutOfRangeException(nameof(type));
            }

            _type = type;
        }
    }
}
