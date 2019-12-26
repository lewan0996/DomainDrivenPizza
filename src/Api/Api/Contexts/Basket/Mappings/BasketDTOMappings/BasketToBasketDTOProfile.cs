using AutoMapper;
using Basket.Application.Queries.DTO;
using Basket.Domain.BasketAggregate;

namespace API.Contexts.Basket.Mappings.BasketDTOMappings
{
    public class BasketToBasketDTOProfile : Profile
    {
        public BasketToBasketDTOProfile()
        {
            CreateMap<CustomerBasket, BasketDTO>();
        }
    }
}
