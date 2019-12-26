using System.Collections.Generic;
using MediatR;

namespace Shared.IntegrationEvents.Basket
{
    public class BasketCheckedOutIntegrationEvent : INotification
    {
        public int BasketId { get; }
        public IDictionary<int, BasketItemInfo> BasketItems { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string EmailAddress { get; }
        public string PhoneNumber { get; }
        public string City { get; }
        public string AddressLine1 { get; }
        public string AddressLine2 { get; }
        public short ZipCode { get; }

        public BasketCheckedOutIntegrationEvent(int basketId, IDictionary<int, BasketItemInfo> basketItems,
            string firstName, string lastName, string emailAddress,
            string phoneNumber, string city, string addressLine1,
            string addressLine2, short zipCode)
        {
            BasketId = basketId;
            BasketItems = basketItems;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            City = city;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            ZipCode = zipCode;
        }
    }

    public class BasketItemInfo
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
    }
}
