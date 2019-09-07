using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Menu.ProductAggregate;
using Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Menu
{
    public class PizzaRepository : Repository<Pizza>
    {
        private readonly MenuDbContext _dbContext;

        public PizzaRepository(MenuDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<Pizza> GetByIdAsync(int id)
        {
            var pizza = await _dbContext.Pizzas
                .Include(p=>p.Ingredients)
                .ThenInclude(pi=>pi.Ingredient)
                .FirstOrDefaultAsync(p => p.Id == id);
            
            return pizza;
        }

        public override async Task<IReadOnlyList<Pizza>> GetAll()
        {
            return await _dbContext.Pizzas
                .Include(p => p.Ingredients)
                .ThenInclude(pi=>pi.Ingredient)
                .ToListAsync();
        }
    }
}
