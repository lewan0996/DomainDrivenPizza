using Application.Basket.Queries.DTO;
using MediatR;

namespace Application.Basket.Commands
{
    public class AddItemToBasketCommand : IRequest<BasketDTO>
    {
        public int? BasketId { get; set; }
        public int ProductId { get; }
        public int Quantity { get; }

        public AddItemToBasketCommand(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
