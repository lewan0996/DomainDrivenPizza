using Domain.Menu.ProductAggregate;
using Infrastructure.Shared;

namespace Infrastructure.Menu
{
    public class IngredientRepository : Repository<Ingredient>
    {
        public IngredientRepository(MenuDbContext dbContext) : base(dbContext)
        {
        }
    }
}
