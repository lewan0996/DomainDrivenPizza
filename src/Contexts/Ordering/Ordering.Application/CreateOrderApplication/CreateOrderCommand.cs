using System.Collections.Generic;
using MediatR;
using Ordering.Application.Queries.DTO;
using Shared.IntegrationEvents.Basket;

namespace Ordering.Application.CreateOrderApplication
{
    public class CreateOrderCommand : IRequest<OrderDTO>
    {
        public CreateOrderCommand(string clientFirstName, string clientLastName, string clientEmailAddress,
            string clientPhoneNumber, string city, string addressLine1, string addressLine2, short zipCode,
            IDictionary<int, BasketItemInfo> basketItems)
        {
            ClientFirstName = clientFirstName;
            ClientLastName = clientLastName;
            ClientEmailAddress = clientEmailAddress;
            ClientPhoneNumber = clientPhoneNumber;
            City = city;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            ZipCode = zipCode;
            BasketItems = basketItems;
        }

        public string ClientFirstName { get; }
        public string ClientLastName { get; }
        public string ClientEmailAddress { get; }
        public string ClientPhoneNumber { get; }

        public string City { get; }
        public string AddressLine1 { get; }
        public string AddressLine2 { get; }
        public short ZipCode { get; }

        public IDictionary<int, BasketItemInfo> BasketItems { get; }
    }
}
