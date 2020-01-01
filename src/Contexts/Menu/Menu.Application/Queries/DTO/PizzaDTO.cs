// ReSharper disable UnusedAutoPropertyAccessor.Global

using System.Collections.Generic;

namespace Menu.Application.Queries.DTO
{
    public class PizzaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float UnitPrice { get; set; }
        public int AvailableQuantity { get; set; } //todo make as computed column
        public List<PizzaIngredientDTO> Ingredients { get; set; }
    }
}
