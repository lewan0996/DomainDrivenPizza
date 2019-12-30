using System.Collections.Generic;
using AutoMapper;
using Basket.Domain.BasketAggregate;

namespace Basket.Application.Queries.DTO
{
    [AutoMap(typeof(CustomerBasket))]
    public class BasketDTO
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public int Id { get; set; }
        // ReSharper disable once CollectionNeverQueried.Global
        public List<BasketItemDTO> Items { get; set; }
    }
}
