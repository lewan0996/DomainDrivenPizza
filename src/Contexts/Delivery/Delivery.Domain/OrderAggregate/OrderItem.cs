using Shared.Domain;
// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Delivery.Domain.OrderAggregate
{
    public class OrderItem : Entity
    {
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public float UnitPrice { get; private set; }

        public OrderItem(int productId, int quantity, float unitPrice)
        {
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        // ReSharper disable once UnusedMember.Local
        private OrderItem() { } // For EF
    }
}
