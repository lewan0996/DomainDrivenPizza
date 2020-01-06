using AutoMapper;
using Ordering.Domain.OrderAggregate;

namespace Ordering.Application.Queries.DTO
{

    [AutoMap(typeof(OrderItem), ReverseMap = true)]
    public class OrderItemDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
    }
}
