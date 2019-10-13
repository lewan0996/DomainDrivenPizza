using Application.Basket.Queries.DTO;
using AutoMapper;
using Domain.Basket.BasketAggregate;

namespace Api.Basket.Mappings.BasketDTOMappings
{
    public class BasketItemToBasketItemDTOProfile : Profile
    {
        public BasketItemToBasketItemDTOProfile()
        {
            CreateMap<BasketItem, BasketItemDTO>();
        }
    }
}
