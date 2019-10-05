using System;
using Domain.SharedKernel;

namespace Domain.Basket.BasketAggregate
{
    public class BasketItem : Entity
    {
        private int _productId;
        public int ProductId => _productId;

        private int _quantity;
        public int Quantity => _quantity;

        public BasketItem(int productId, int quantity)
        {
            _productId = productId;
            _quantity = quantity;
        }

        public void SetQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity),
                    "Quantity of a basket item must be greater than zero");
            }

            _quantity = quantity;
        }
    }
}
