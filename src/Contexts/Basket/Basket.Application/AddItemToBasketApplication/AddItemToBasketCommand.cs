using Basket.Application.Queries.DTO;
using MediatR;

namespace Basket.Application.AddItemToBasketApplication
{
    public class AddItemToBasketCommand : IRequest<BasketDTO>
    {
        public int? BasketId { get; set; }
        public int ProductId { get; }
        public int Quantity { get; }
        public float UnitPrice { get; }

        public AddItemToBasketCommand(int productId, int quantity, float unitPrice)
        {
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
