#pragma warning disable 1591
namespace Api.Menu.DTO
{
    public class CreateIngredientDTO : CreateProductDTO
    {
        public bool IsSpicy { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
    }
}
