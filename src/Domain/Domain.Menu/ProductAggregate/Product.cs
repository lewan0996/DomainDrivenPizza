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

        public void SetName(ProductName name)
        {
            _name = name;
        }

        public void SetDescription(ProductDescription description)
        {
            _description = description;
        }

        public void SetUnitPrice(float unitPrice)
        {
            _unitPrice = unitPrice;
        }
    }
}
