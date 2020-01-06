using System;
using System.Collections.Generic;
using Shared.Domain;

namespace Menu.Domain.ProductAggregate
{
    public class ProductDescription : ValueObject
    {
        public string Value { get; private set; }

        public ProductDescription(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new DomainException(new ArgumentException("Product description can't be empty.", nameof(value)));
            }

            Value = value;
        }
        
        protected override IEnumerable<object> GetAtomicValues()
        {
            return new[] {Value};
        }
    }
}