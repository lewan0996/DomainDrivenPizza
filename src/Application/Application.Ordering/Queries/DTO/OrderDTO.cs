using Domain.Ordering.OrderAggregate;

namespace Application.Ordering.Queries.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public ClientDTO Client { get; set; }
        public AddressDTO Address { get; set; }
        public OrderItemDTO[] Items { get; set; }
        public OrderStatus Status { get; set; }
    }
}
