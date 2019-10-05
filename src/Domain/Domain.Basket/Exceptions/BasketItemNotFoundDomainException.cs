using System;

namespace Domain.Basket.Exceptions
{
    public class BasketItemNotFoundDomainException : Exception
    {
        public int ProductId { get; }

        public BasketItemNotFoundDomainException(int productId) : base(
            $"Product of id {productId} is not present in the basket")
        {
            ProductId = productId;
        }
    }
}
