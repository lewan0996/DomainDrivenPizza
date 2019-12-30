using AutoMapper;
using Basket.Application.AddItemToBasketApplication;

#pragma warning disable 1591
namespace API.Contexts.Basket.DTO
{
    [AutoMap(typeof(AddItemToBasketCommand), ReverseMap = true)]
    public class AddItemToBasketDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
    }
}
