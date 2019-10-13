using Api.Basket.DTO;
using Application.Basket.Commands;
using AutoMapper;

namespace Api.Basket.Mappings.BasketDTOMappings
{
    public class AddItemToBasketDTOToAddItemToBasketCommandProfile: Profile
    {
        public AddItemToBasketDTOToAddItemToBasketCommandProfile()
        {
            CreateMap<AddItemToBasketDTO, AddItemToBasketCommand>();
        }
    }
}
