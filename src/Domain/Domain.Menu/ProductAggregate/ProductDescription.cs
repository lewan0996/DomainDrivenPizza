using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Domain.SharedKernel;

namespace Domain.Menu.ProductAggregate
{
    public class ProductDescription : ValueObject
    {
        private string _value;
        public string Value => _value;

        public ProductDescription(string value)
        {
            Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(value),
                "Product description can't be empty.");
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