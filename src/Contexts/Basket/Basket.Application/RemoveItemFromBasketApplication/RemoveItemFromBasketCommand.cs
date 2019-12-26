using MediatR;

namespace Basket.Application.RemoveItemFromBasketApplication
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
