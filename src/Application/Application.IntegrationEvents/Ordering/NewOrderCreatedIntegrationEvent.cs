using System.Collections.Generic;
using MediatR;

namespace Application.IntegrationEvents.Ordering
{
    public class NewOrderCreatedIntegrationEvent : INotification
    {
        public NewOrderCreatedIntegrationEvent(int orderId, IReadOnlyList<(int id, int quantity)> itemsIdsAndQuantity)
        {
            OrderId = orderId;
            ItemsIdsAndQuantity = itemsIdsAndQuantity;
        }

        public int OrderId { get; }
        public IReadOnlyList<(int id, int quantity)> ItemsIdsAndQuantity { get; }
    }
}
