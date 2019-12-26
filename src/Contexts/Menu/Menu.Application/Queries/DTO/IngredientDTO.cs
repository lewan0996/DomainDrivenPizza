namespace Menu.Application.Queries.DTO
{
    public class IngredientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float UnitPrice { get; set; }
        public int AvailableQuantity { get; set; }
        public bool IsSpicy { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }        
    }
}
