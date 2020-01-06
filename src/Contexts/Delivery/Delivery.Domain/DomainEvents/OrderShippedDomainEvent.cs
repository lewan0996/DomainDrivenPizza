using Delivery.Domain.OrderAggregate;
using MediatR;

namespace Delivery.Domain.DomainEvents
{
    public class OrderShippedDomainEvent : INotification
    {
        public OrderShippedDomainEvent(Order order)
        {
            Order = order;
        }

        public Order Order { get; }
    }
}
