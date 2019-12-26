using System.Collections.Generic;

namespace Basket.Application.Queries.DTO
{
    public class BasketDTO
    {
        public int Id { get; set; }
        public List<BasketItemDTO> Items { get; set; }
    }
}
