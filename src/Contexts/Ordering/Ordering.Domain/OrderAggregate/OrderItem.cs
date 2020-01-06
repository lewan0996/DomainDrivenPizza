using System;
using Shared.Domain;

namespace Ordering.Domain.OrderAggregate
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

        public float? TotalPrice => UnitPrice * Quantity;

        public void SetUnitPrice(float unitPrice)
        {
            if (unitPrice < 0)
            {
                throw new DomainException(new ArgumentOutOfRangeException(nameof(unitPrice),
                    "Unit price cannot be negative"));
            }

            UnitPrice = unitPrice;
        }
    }
}
