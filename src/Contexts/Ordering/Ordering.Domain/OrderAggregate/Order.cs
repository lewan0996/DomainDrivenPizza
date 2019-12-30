using System.Collections.Generic;
using System.Linq;
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
            if (Status != OrderStatus.InPreparation)
            {
                throw new DomainException("Cannot ship an unprepared order");
            }
            Status = OrderStatus.InDelivery;
        }

        public void Complete()
        {
            if (Status != OrderStatus.InDelivery)
            {
                throw new DomainException("Cannot complete a not shipped order");
            }
            Status = OrderStatus.Completed;
        }

        public void StartPreparation()
        {
            if (Status != OrderStatus.New)
            {
                throw new DomainException("Cannot start preparation of an order with status different than 'New'");
            }

            var allPricesSet = Items.All(i => i.UnitPrice.HasValue);

            if (!allPricesSet)
            {
                throw new DomainException(
                    $"Cannot start preparation of an order (id: {Id}) with items with unknown price.");
            }

            Status = OrderStatus.InPreparation;
        }

        public void Cancel()
        {
            if (Status != OrderStatus.New)
            {
                throw new DomainException("Cannot cancel an already started order");
            }

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
