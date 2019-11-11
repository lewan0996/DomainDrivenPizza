using System.Collections.Generic;
using Domain.SharedKernel;

namespace Domain.Ordering.OrderAggregate
{
    public class Order : AggregateRoot
    {
        private Client _client;
        public Client Client => _client;

        private Address _address;
        public Address Address => _address;

        private List<OrderItem> _items;
        public IReadOnlyList<OrderItem> Items => _items;

        private OrderStatus _status;
        public OrderStatus Status => _status;

        public Order(Client client, Address address, List<OrderItem> items)
        {
            _client = client;
            _address = address;
            _items = items;
            _status = OrderStatus.Pending;
        }

        public Order() { }

        public void Ship()
        {
            _status = OrderStatus.InDelivery;
        }

        public void Complete()
        {
            _status = OrderStatus.Completed;
        }

        public void StartPreparation()
        {
            _status = OrderStatus.InPreparation;
        }

        public void Cancel()
        {
            _status = OrderStatus.Cancelled;
        }
    }

    public enum OrderStatus
    {
        Pending = 0,
        InPreparation = 1,
        InDelivery = 2,
        Completed = 3,
        Cancelled = 4
    }
}
