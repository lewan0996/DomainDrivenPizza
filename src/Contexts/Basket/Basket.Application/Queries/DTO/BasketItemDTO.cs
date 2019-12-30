using AutoMapper;
using Basket.Domain.BasketAggregate;

namespace Basket.Application.Queries.DTO
{
    [AutoMap(typeof(BasketItem), ReverseMap = true)]
    public class BasketItemDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
