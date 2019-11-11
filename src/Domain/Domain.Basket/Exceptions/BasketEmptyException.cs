using System;

namespace Domain.Basket.Exceptions
{
    public class BasketEmptyException : Exception
    {
        public int BasketId { get; }

        public BasketEmptyException(int basketId) : base($"Basket {basketId} is empty")
        {
            BasketId = basketId;
        }
    }
}
