using MediatR;

namespace Application.Basket.Commands
{
    public class CheckoutCommand : IRequest
    {
        public CheckoutCommand(int basketId)
        {
            BasketId = basketId;
        }

        public int BasketId { get; }
    }
}
