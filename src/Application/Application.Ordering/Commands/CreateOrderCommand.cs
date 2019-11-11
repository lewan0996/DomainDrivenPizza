using System.Collections.Generic;
using Application.Ordering.Queries.DTO;
using MediatR;

namespace Application.Ordering.Commands
{
    public class CreateOrderCommand : IRequest<OrderDTO>
    {
        public CreateOrderCommand(string clientFirstName, string clientLastName, string clientEmailAddress,
            string clientPhoneNumber, string city, string addressLine1, string addressLine2, short zipCode,
            IReadOnlyList<OrderItemDTO> items)
        {
            ClientFirstName = clientFirstName;
            ClientLastName = clientLastName;
            ClientEmailAddress = clientEmailAddress;
            ClientPhoneNumber = clientPhoneNumber;
            City = city;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            ZipCode = zipCode;
            Items = items;
        }

        public string ClientFirstName { get; }
        public string ClientLastName { get; }
        public string ClientEmailAddress { get; }
        public string ClientPhoneNumber { get; }

        public string City { get; }
        public string AddressLine1 { get; }
        public string AddressLine2 { get; }
        public short ZipCode { get; }

        public IReadOnlyList<OrderItemDTO> Items { get; }
    }
}
