using System.Collections.Generic;
using MediatR;

namespace Application.IntegrationEvents.Basket
{
    public class BasketCheckedOutIntegrationEvent : INotification
    {
        public int BasketId { get; }
        public IReadOnlyList<(int id, int quantity)> BasketItemIdsAndQuantity { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string EmailAddress { get; }
        public string PhoneNumber { get; }
        public string City { get; }
        public string AddressLine1 { get; }
        public string AddressLine2 { get; }
        public short ZipCode { get; }

        public BasketCheckedOutIntegrationEvent(int basketId, IReadOnlyList<(int id, int quantity)> basketItemIdsAndQuantity,
            string firstName, string lastName, string emailAddress,
            string phoneNumber, string city, string addressLine1,
            string addressLine2, short zipCode)
        {
            BasketId = basketId;
            BasketItemIdsAndQuantity = basketItemIdsAndQuantity;
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
}
