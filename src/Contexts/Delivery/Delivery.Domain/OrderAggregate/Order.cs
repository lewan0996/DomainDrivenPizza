using System;
using System.Collections.Generic;
using System.Linq;
using Shared.Domain;
using Shared.Domain.ValueObjects;
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Delivery.Domain.OrderAggregate
{
    public class Order : AggregateRoot
    {
        public int OrderingContextOrderId { get; private set; }
        public Address Address { get; private set; }
        public Client Client { get; private set; }
        public int SupplierId { get; private set; }
        public OrderStatus Status { get; set; }
        private List<OrderItem> _items;
        public IReadOnlyList<OrderItem> Items => _items;

        public Order(Address address, Client client, int supplierId, List<OrderItem> items, int orderingContextOrderId)
        {
            Address = address ?? throw new DomainException(new ArgumentNullException(nameof(address)));
            Client = client ?? throw new DomainException(new ArgumentNullException(nameof(client)));
            SupplierId = supplierId;
            _items = items ?? throw new DomainException(new ArgumentNullException(nameof(items)));
            OrderingContextOrderId = orderingContextOrderId;
            Status = OrderStatus.New;
        }

        // ReSharper disable once UnusedMember.Local
        private Order(int orderingContextOrderId)
        {
            OrderingContextOrderId = orderingContextOrderId;
        } // For EF

        public void StartDelivery()
        {
            if (Status != OrderStatus.New)
            {
                throw new DomainException("Only new order can be delivered.");
            }

            Status = OrderStatus.InDelivery;
        }

        public void FinishDelivery()
        {
            if (Status != OrderStatus.InDelivery)
            {
                throw new DomainException("Cannot finish delivery of an order whose delivery has not started");
            }

            Status = OrderStatus.Delivered;
        }
    }

    public enum OrderStatus
    {
        New = 1,
        InDelivery = 2,
        Delivered = 3
    }
}
