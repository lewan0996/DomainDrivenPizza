using System.Collections.Generic;
using MediatR;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Shared.IntegrationEvents.Menu
{
    public class OrderAcceptedIntegrationEvent : INotification
    {
        public int OrderId { get; }
        public IReadOnlyDictionary<int,ValidatedOrderItemInfo> OrderItemInfoDictionary { get; }

        public OrderAcceptedIntegrationEvent(int orderId,
            IReadOnlyDictionary<int, ValidatedOrderItemInfo> orderItemInfoDictionary)
        {
            OrderId = orderId;
            OrderItemInfoDictionary = orderItemInfoDictionary;
        }
    }

    public class ValidatedOrderItemInfo
    {
        public int ProductId { get; }
        public int Quantity { get; }
        public float UnitPrice { get; }

        public ValidatedOrderItemInfo(int productId, int quantity, float unitPrice)
        {
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
