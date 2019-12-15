using System;
using Domain.SharedKernel;

namespace Domain.Ordering.OrderAggregate
{
    public class OrderItem : Entity
    {
        public int ProductId { get; private set; }

        public int Quantity { get; private set; }

        public float? UnitPrice { get; private set; }

        public OrderItem(int productId, int quantity, float? unitPrice)
        {
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public float TotalPrice => !UnitPrice.HasValue
            ? throw new ArgumentNullException(nameof(UnitPrice))
            : UnitPrice.Value * Quantity;
    }
}
