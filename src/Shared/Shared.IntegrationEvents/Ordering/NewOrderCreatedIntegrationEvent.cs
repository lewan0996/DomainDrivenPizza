using System.Collections.Generic;
using MediatR;
using Shared.IntegrationEvents.Basket;

namespace Shared.IntegrationEvents.Ordering
{
    public class NewOrderCreatedIntegrationEvent : INotification
    {
        public NewOrderCreatedIntegrationEvent(int orderId, IDictionary<int, BasketItemInfo> basketItems)
        {
            OrderId = orderId;
            BasketItems = basketItems;
        }

        public int OrderId { get; }
        public IDictionary<int, BasketItemInfo> BasketItems { get; }
    }
}
