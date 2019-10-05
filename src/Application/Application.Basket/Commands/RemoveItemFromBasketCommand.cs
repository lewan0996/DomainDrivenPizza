using MediatR;

namespace Application.Basket.Commands
{
    public class RemoveItemFromBasketCommand : IRequest
    {
        public int BasketId { get; }
        public int ProductId { get; }

        public RemoveItemFromBasketCommand(int basketId, int productId)
        {
            BasketId = basketId;
            ProductId = productId;
        }
    }
}
