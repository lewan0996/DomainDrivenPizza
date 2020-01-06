using MediatR;

namespace Shared.IntegrationEvents.Menu
{
    public class OrderRejectedIntegrationEvent : INotification
    {
        public OrderRejectedIntegrationEvent(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; }
    }
}
