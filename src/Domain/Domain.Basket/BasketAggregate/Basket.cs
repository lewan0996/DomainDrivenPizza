using System.Collections.Generic;
using Domain.Basket.Exceptions;
using Domain.SharedKernel;

namespace Domain.Basket.BasketAggregate
{
    public class Basket : AggregateRoot
    {
#pragma warning disable 649
        private List<BasketItem> _items;
#pragma warning restore 649
        public IReadOnlyList<BasketItem> Items => _items;

        public void AddItemToBasket(int productId, int quantity)
        {
            var basketItem = new BasketItem(productId, quantity);

            var productExistsInBasket = _items.Contains(basketItem);

            if (productExistsInBasket)
            {
                var existingBasketItem = _items.Find(item => item.ProductId == productId);
                existingBasketItem.SetQuantity(existingBasketItem.Quantity + quantity);
            }
            else
            {
                _items.Add(basketItem);
            }
        }

        public void RemoveItemFromBasket(int productId)
        {
            var basketItemToRemove = _items.Find(item => item.ProductId == productId);
            if (basketItemToRemove == null)
            {
                throw new BasketItemNotFoundDomainException(productId);
            }

            _items.Remove(basketItemToRemove);
        }

        public void SetItemQuantity(int productId, int quantity)
        {
            var basketItemToUpdate = _items.Find(item => item.ProductId == productId);
            if (basketItemToUpdate == null)
            {
                throw new BasketItemNotFoundDomainException(productId);
            }

            basketItemToUpdate.SetQuantity(quantity);
        }
    }
}
