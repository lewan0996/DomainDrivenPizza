using System.Collections.Generic;
using Shared.Domain;

namespace Ordering.Domain.OrderAggregate
{
    public class Order : AggregateRoot
    {
        public Client Client { get; private set; }

        public Address Address { get; private set; }

        private List<OrderItem> _items;
        public IReadOnlyList<OrderItem> Items => _items;

        public OrderStatus Status { get; private set; }

        public Order(Client client, Address address, List<OrderItem> items)
        {
            Client = client;
            Address = address;
            _items = items;
            Status = OrderStatus.New;
        }

        // ReSharper disable once UnusedMember.Local
        private Order() { } // For EF

        public void Ship()
        {
            Status = OrderStatus.InDelivery;
        }

        public void Complete()
        {
            Status = OrderStatus.Completed;
        }

        public void StartPreparation()
        {
            Status = OrderStatus.InPreparation;
        }

        public void Cancel()
        {
            Status = OrderStatus.Cancelled;
        }
    }

    public enum OrderStatus
    {
        New = 1,
        InPreparation = 2,
        InDelivery = 3,
        Completed = 4,
        Cancelled = 5
    }
}
