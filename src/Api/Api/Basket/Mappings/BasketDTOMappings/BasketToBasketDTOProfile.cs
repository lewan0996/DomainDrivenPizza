using Application.Basket.Queries.DTO;
using AutoMapper;

namespace Api.Basket.Mappings.BasketDTOMappings
{
    public class BasketToBasketDTOProfile : Profile
    {
        public BasketToBasketDTOProfile()
        {
            CreateMap<Domain.Basket.BasketAggregate.Basket, BasketDTO>();
        }
    }
}
