using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Domain.SharedKernel;

namespace Domain.Menu.ProductAggregate
{
    public class ProductName : ValueObject
    {
        private string _value;
        public string Value => _value;

        public ProductName(string value)
        {
            Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(value),
                "Product name can't be empty.");

            _value = value;
        }

        public ProductName()
        {
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            return new[] {_value};
        }
    }
}
