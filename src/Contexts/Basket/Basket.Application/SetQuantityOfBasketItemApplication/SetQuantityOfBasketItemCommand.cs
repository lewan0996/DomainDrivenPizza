using MediatR;

namespace Basket.Application.SetQuantityOfBasketItemApplication
{
    public class SetQuantityOfBasketItemCommand : IRequest
    {
        public SetQuantityOfBasketItemCommand(int basketId, int productId, int quantity)
        {
            BasketId = basketId;
            ProductId = productId;
            Quantity = quantity;
        }

        public int BasketId { get; }
        public int ProductId { get; }
        public int Quantity { get; }
    }
}
