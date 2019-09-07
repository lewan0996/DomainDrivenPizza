using System.Runtime.Serialization;

namespace Domain.Menu.ProductAggregate
{
    public enum ProductType
    {
        [EnumMember(Value = "Pizza")]
        Pizza = 0,
        [EnumMember(Value = "Drink")]
        Drink = 1,
        [EnumMember(Value = "Salad")]
        Salad = 2,
        [EnumMember(Value = "Dessert")]
        Dessert = 3,
        [EnumMember(Value = "Sauce")]
        Sauce = 4,
        [EnumMember(Value = "Ingredient")]
        Ingredient = 5,
        [EnumMember(Value = "Other")]
        Other = 6
    }
}