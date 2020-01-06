using MediatR;

namespace Delivery.Application.FinishDeliveryApplication
{
    public class FinishDeliveryCommand : IRequest
    {
        public int OrderId { get; }

        public FinishDeliveryCommand(int orderId)
        {
            OrderId = orderId;
        }
    }
}
