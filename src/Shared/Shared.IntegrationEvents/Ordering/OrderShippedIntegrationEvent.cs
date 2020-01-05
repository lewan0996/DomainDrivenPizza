using System.Collections.Generic;
using MediatR;
using Shared.IntegrationEvents.Menu;

namespace Shared.IntegrationEvents.Ordering
{
    public class OrderShippedIntegrationEvent : INotification
    {
        public string City { get; }
        public string AddressLine1 { get; }
        public string AddressLine2 { get; }
        public short ZipCode { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string EmailAddress { get; }
        public string PhoneNumber { get; }
        public List<ValidatedOrderItemInfo> Items { get; }

        public OrderShippedIntegrationEvent(string city, string addressLine1, string addressLine2, short zipCode, string firstName, string lastName, string emailAddress, string phoneNumber, List<ValidatedOrderItemInfo> items)
        {
            City = city;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            ZipCode = zipCode;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            Items = items;
        }
    }
}
