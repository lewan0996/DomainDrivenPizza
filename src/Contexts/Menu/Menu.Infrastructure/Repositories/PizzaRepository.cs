using System.Collections.Generic;
using System.Threading.Tasks;
using Menu.Domain.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Shared.Domain;
using Shared.Infrastructure;

namespace Menu.Infrastructure.Repositories
{
    public class PizzaRepository : Repository<Pizza, MenuDbContext>
    {
        public PizzaRepository(MenuDbContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork)
        {
        }

        public override async Task<Pizza> GetByIdAsync(int id)
        {
            return await DbContext.Pizzas
                .Include(p => p.Ingredients)
                .ThenInclude(pi => pi.Ingredient)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<IReadOnlyList<Pizza>> GetAll()
        {
            return await DbContext.Pizzas
                .Include(p => p.Ingredients)
                .ThenInclude(pi => pi.Ingredient)
                .ToListAsync();
        }
    }
}
