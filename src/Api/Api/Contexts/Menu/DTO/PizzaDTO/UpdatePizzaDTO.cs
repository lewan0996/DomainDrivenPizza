// ReSharper disable UnusedAutoPropertyAccessor.Global

using AutoMapper;
using Menu.Application.PizzaApplications.UpdatePizzaApplication;

#pragma warning disable 1591

namespace API.Contexts.Menu.DTO.PizzaDTO
{
    [AutoMap(typeof(UpdatePizzaCommand), ReverseMap = true)]
    public class UpdatePizzaDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float? UnitPrice { get; set; }
        public int[] IngredientIds { get; set; }
    }
}
