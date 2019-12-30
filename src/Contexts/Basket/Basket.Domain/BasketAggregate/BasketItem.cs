using System;
using Shared.Domain;
// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Basket.Domain.BasketAggregate
{
    public class BasketItem : Entity
    {
        public int ProductId { get; private set; }

        public int Quantity { get; private set; }

        public int BasketId { get; private set; }

        public float UnitPrice { get; private set; }

        public BasketItem(int productId, int quantity, float unitPrice)
        {
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public void SetQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new DomainException(new ArgumentOutOfRangeException(nameof(quantity),
                    "Quantity of a basket item must be greater than zero"));
            }

            Quantity = quantity;
        }
    }
}
