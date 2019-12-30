using System.Collections.Generic;
using System.Linq;
using Basket.Domain.Exceptions;
using Shared.Domain;
#pragma warning disable 649

namespace Basket.Domain.BasketAggregate
{
    public class CustomerBasket : AggregateRoot
    {
        private List<BasketItem> _items;

        public IReadOnlyList<BasketItem> Items => _items;

        public void AddItemToBasket(int productId, int quantity, float unitPrice) // unitPrice is validated after checkout
        {
            var basketItem = new BasketItem(productId, quantity, unitPrice);

            var productExistsInBasket = Items.Any(bi => bi.ProductId == productId);

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

        public void Clear()
        {
            _items.Clear();
        }
    }
}
