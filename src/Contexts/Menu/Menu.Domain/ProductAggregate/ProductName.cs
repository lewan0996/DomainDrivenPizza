using System;
using System.Collections.Generic;
using Shared.Domain;

namespace Menu.Domain.ProductAggregate
{
    public class ProductName : ValueObject
    {
        public string Value { get; private set; }

        public ProductName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new DomainException(new ArgumentException("Product name can't be empty.", nameof(value)));
            }

            Value = value;
        }
        
        protected override IEnumerable<object> GetAtomicValues()
        {
            return new[] { Value };
        }
    }
}
