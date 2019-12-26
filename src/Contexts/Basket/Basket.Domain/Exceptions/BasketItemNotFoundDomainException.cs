using Shared.Domain;

namespace Basket.Domain.Exceptions
{
    public class BasketItemNotFoundDomainException : DomainException
    {
        public int ProductId { get; }

        public BasketItemNotFoundDomainException(int productId) : base(
            $"Product of id {productId} is not present in the basket")
        {
            ProductId = productId;
        }
    }
}
