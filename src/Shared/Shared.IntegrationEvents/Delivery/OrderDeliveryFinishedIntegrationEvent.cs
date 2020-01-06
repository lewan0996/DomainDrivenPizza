using MediatR;

namespace Shared.IntegrationEvents.Delivery
{
    public class OrderDeliveryFinishedIntegrationEvent : INotification
    {
        public OrderDeliveryFinishedIntegrationEvent(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; }
    }
}
