using System;
using Shared.Domain;
// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Delivery.Domain.SupplierAggregate
{
    public class Supplier : AggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public SupplierStatus Status { get; private set; }

        public Supplier(string firstName, string lastName)
        {

            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new DomainException(new ArgumentException("First name of a supplier cannot be empty",
                    nameof(firstName)));
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new DomainException(new ArgumentException("Last name of a supplier cannot be empty",
                    nameof(lastName)));
            }

            FirstName = firstName;
            LastName = lastName;
            Status = SupplierStatus.Free;
        }

        // ReSharper disable once UnusedMember.Local
        private Supplier() { } // For EF

        public void StartDelivery()
        {
            if (Status != SupplierStatus.Free)
            {
                throw new DomainException("Only a free supplier can start delivery.");
            }
            Status = SupplierStatus.Occupied;
        }

        public void FinishDelivery()
        {
            if (Status != SupplierStatus.Occupied)
            {
                throw new DomainException("Only an occupied supplier can finish delivery.");
            }
            Status = SupplierStatus.Free;
        }
    }

    public enum SupplierStatus
    {
        Free = 1,
        Occupied = 2
    }
}
