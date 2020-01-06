using MediatR;

namespace Ordering.Application.ShipOrderApplication
{
    public class ShipOrderCommand : IRequest
    {
        public ShipOrderCommand(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; }
    }
}
