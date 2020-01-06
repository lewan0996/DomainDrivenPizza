using Shared.Domain;

namespace Basket.Domain.Exceptions
{
    public class BasketEmptyException : DomainException
    {
        public int BasketId { get; }

        public BasketEmptyException(int basketId) : base($"CustomerBasket {basketId} is empty")
        {
            BasketId = basketId;
        }
    }
}
