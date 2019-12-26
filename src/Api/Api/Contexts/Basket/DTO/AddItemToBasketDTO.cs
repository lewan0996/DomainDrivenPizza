namespace API.Contexts.Basket.DTO
{
    public class AddItemToBasketDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
    }
}
