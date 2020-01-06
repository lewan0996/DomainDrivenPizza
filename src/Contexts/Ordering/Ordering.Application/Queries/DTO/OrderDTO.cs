using System.Collections.Generic;
using AutoMapper;
using Ordering.Domain.OrderAggregate;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Ordering.Application.Queries.DTO
{
    [AutoMap(typeof(Order), ReverseMap = true)]
    public class OrderDTO
    {
        public int Id { get; set; }
        public ClientDTO Client { get; set; }
        public AddressDTO Address { get; set; }
        public List<OrderItemDTO> Items { get; set; }
        public OrderStatus Status { get; set; }
    }
}
