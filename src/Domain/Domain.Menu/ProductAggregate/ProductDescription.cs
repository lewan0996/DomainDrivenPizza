using System;
using System.Collections.Generic;
using Domain.SharedKernel;

namespace Domain.Menu.ProductAggregate
{
    public class ProductDescription : ValueObject
    {
        private string _value;
        public string Value => _value;

        public ProductDescription(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Product description can't be empty.", nameof(value));
            }

            _value = value;
        }

        public ProductDescription()
        {
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            return new[] {_value};
        }
    }
}