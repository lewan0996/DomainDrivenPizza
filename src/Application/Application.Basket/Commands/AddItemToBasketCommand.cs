using MediatR;

namespace Application.Basket.Commands
{
    public class AddItemToBasketCommand : IRequest
    {
        public int BasketId { get; }
        public int ProductId { get; }
        public int Quantity { get; }

        public AddItemToBasketCommand(int basketId, int productId, int quantity)
        {
            BasketId = basketId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
