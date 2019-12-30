using System.Collections.Generic;
using Menu.Domain.ProductAggregate;
using Shared.Domain;

namespace Menu.Infrastructure
{
    public static class SeedData
    {
        public static Ingredient[] Ingredients { get; private set; }
        public static Pizza[] Pizzas { get; private set; }

        static SeedData()
        {
            Init();
        }

        private static void Init()
        {
            Ingredients = InitAndGetIngredients();
            Pizzas = InitAndGetPizzas(Ingredients);
        }

        private static Ingredient[] InitAndGetIngredients()
        {
            var ingredients = new[]
            {
                new Ingredient("Cheese", "Yellow cheese", 2.00f, false, true, false, 100),
                new Ingredient("Onion", "Onion", 2.00f, false, true, true, 100),
                new Ingredient("Chilli pepper", "Red, hot chilli pepper", 2.00f, true, true, true, 100),
                new Ingredient("Pineapple", "Fresh pineapple", 3.00f, false, true, true, 10),
                new Ingredient("Ham", "Mechanically separated", 1.50f, false, false, false, 200)
            };

            SetEntityIds(ingredients);

            return ingredients;
        }

        private static Pizza[] InitAndGetPizzas(Ingredient[] ingredients)
        {
            var hawaiianPizza = new Pizza("Hawaiian", "Cheese, ham, pineapple", 30);
            hawaiianPizza.AddIngredient(ingredients[0]); // cheese
            hawaiianPizza.AddIngredient(ingredients[3]); // pineapple
            hawaiianPizza.AddIngredient(ingredients[4]); // ham

            var spicyPizza = new Pizza("Spicy", "Very spicy pizza", 35);
            spicyPizza.AddIngredient(ingredients[1]); // onion
            spicyPizza.AddIngredient(ingredients[2]); // chilli pepper
            spicyPizza.AddIngredient(ingredients[0]); // cheese

            var pizzas = new[] {hawaiianPizza, spicyPizza};
            SetEntityIds(pizzas);

            return pizzas;
        }

        private static void SetEntityIds(IEnumerable<Entity> entities)
        {
            var idPropertyInfo = typeof(Entity).GetProperty(nameof(Entity.Id));
            var id = 1;

            foreach (var entity in entities)
            {
                idPropertyInfo?.SetValue(entity, id);
                id++;
            }
        }
    }
}
