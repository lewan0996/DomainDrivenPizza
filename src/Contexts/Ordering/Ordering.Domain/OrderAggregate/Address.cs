using System;
using System.Collections.Generic;
using Shared.Domain;

namespace Ordering.Domain.OrderAggregate
{
    public class Address : ValueObject
    {
        public string City { get; private set; }

        public string AddressLine1 { get; private set; }

        public string AddressLine2 { get; private set; }

        public short ZipCode { get; private set; }

        public Address(string city, string addressLine1, string addressLine2, short zipCode)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new DomainException(new ArgumentException("Value cannot be null or whitespace.", nameof(city)));

            if (string.IsNullOrWhiteSpace(addressLine1))
                throw new DomainException(new ArgumentException("Value cannot be null or whitespace.",
                    nameof(addressLine1)));

            if (string.IsNullOrWhiteSpace(addressLine2))
                throw new DomainException(new ArgumentException("Value cannot be null or whitespace.",
                    nameof(addressLine2)));

            City = city;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            ZipCode = zipCode;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return City;
            yield return AddressLine1;
            yield return AddressLine2;
            yield return ZipCode;
        }
    }
}
