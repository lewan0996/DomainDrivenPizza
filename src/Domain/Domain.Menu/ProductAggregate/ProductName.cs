using System;
using System.Collections.Generic;
using Domain.SharedKernel;

namespace Domain.Menu.ProductAggregate
{
    public class ProductName : ValueObject
    {
        private string _value;
        public string Value => _value;

        public ProductName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Product name can't be empty.", nameof(value));
            }

            _value = value;
        }

        public ProductName()
        {
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            return new[] { _value };
        }
    }
}
