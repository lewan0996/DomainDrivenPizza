using API.Contexts.Basket.DTO;
using AutoMapper;
using Basket.Application.AddItemToBasketApplication;

namespace API.Contexts.Basket.Mappings.BasketDTOMappings
{
    public class AddItemToBasketDTOToAddItemToBasketCommandProfile: Profile
    {
        public AddItemToBasketDTOToAddItemToBasketCommandProfile()
        {
            CreateMap<AddItemToBasketDTO, AddItemToBasketCommand>();
        }
    }
}
