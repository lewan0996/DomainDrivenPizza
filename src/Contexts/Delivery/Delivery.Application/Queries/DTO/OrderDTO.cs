using System.Collections.Generic;
using System.Linq;
using Delivery.Domain.OrderAggregate;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Delivery.Application.Queries.DTO
{
    public class OrderDTO
    {
        public string City { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public short ZipCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int SupplierId { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItemDTO> Items { get; set; }
        public float FullPrice => Items.Sum(i => i.UnitPrice);
    }
}
