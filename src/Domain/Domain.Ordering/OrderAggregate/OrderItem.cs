using Domain.SharedKernel;

namespace Domain.Ordering.OrderAggregate
{
    public class OrderItem : Entity
    {
        private int _productId;
        public int ProductId => _productId;

        private int _quantity;
        public int Quantity => _quantity;

        private float _unitPrice;
        public float UnitPrice => _unitPrice;

        public OrderItem(int productId, int quantity, float unitPrice)
        {
            _productId = productId;
            _quantity = quantity;
            _unitPrice = unitPrice;
        }

        protected OrderItem() { }

        public float TotalPrice => _unitPrice * _quantity;
    }
}
