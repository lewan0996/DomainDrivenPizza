using System.Collections.Generic;

namespace Application.Basket.Queries.DTO
{
    public class BasketDTO
    {
        public int Id { get; set; }
        public List<BasketItemDTO> Items { get; set; }
    }
}
