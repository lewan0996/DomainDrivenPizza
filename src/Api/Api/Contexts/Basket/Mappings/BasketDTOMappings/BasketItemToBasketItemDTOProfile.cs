using AutoMapper;
using Basket.Application.Queries.DTO;
using Basket.Domain.BasketAggregate;

namespace API.Contexts.Basket.Mappings.BasketDTOMappings
{
    public class BasketItemToBasketItemDTOProfile : Profile
    {
        public BasketItemToBasketItemDTOProfile()
        {
            CreateMap<BasketItem, BasketItemDTO>();
        }
    }
}
