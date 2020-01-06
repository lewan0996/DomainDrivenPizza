using System.Threading.Tasks;
using Menu.Domain.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Shared.Domain;
using Shared.Infrastructure;

namespace Menu.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product,MenuDbContext>
    {
        public ProductRepository(MenuDbContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork)
        {
        }

        public override async Task<Product> GetByIdAsync(int id) // Workaround for lack of TPT support in EF Core
        {
            var ingredient = await DbContext.Ingredients.FindAsync(id);

            if (ingredient != null)
            {
                return ingredient;
            }

            return await DbContext.Pizzas
                .Include(p => p.Ingredients)
                .ThenInclude(pi => pi.Ingredient)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
