
using System;
using System.Collections.Generic;
using Domain.SharedKernel;

namespace Domain.Ordering.OrderAggregate
{
    public class Address : ValueObject
    {
        private string _city;
        public string City => _city;

        private string _addressLine1;
        public string AddressLine1 => _addressLine1;

        private string _addressLine2;
        public string AddressLine2 => _addressLine2;

        private short _zipCode; // todo validate zipcode
        public short ZipCode => _zipCode;

        public Address(string city, string addressLine1, string addressLine2, short zipCode)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(city));

            if (string.IsNullOrWhiteSpace(addressLine1))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(addressLine1));

            if (string.IsNullOrWhiteSpace(addressLine2))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(addressLine2));

            _city = city;
            _addressLine1 = addressLine1;
            _addressLine2 = addressLine2;
            _zipCode = zipCode;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return _city;
            yield return _addressLine1;
            yield return _addressLine2;
            yield return _zipCode;
        }
    }
}
