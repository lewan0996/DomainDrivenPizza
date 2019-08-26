using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Menu.ProductAggregate;
using Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Menu
{
    public class PizzaRepository : IRepository<Pizza>
    {
        private readonly MenuDbContext _dbContext;

        public PizzaRepository(MenuDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Pizza item)
        {
            await _dbContext.Pizzas.AddAsync(item);
        }

        public async Task<Pizza> GetByIdAsync(int id)
        {
            var pizza = await _dbContext.Pizzas
                .Include(p=>p.Ingredients)
                .ThenInclude(pi=>pi.Ingredient)
                .FirstOrDefaultAsync(p => p.Id == id);
            
            return pizza;
        }

        public async Task<IReadOnlyList<Pizza>> GetAll()
        {
            return await _dbContext.Pizzas
                .Include(p => p.Ingredients)
                .ThenInclude(pi=>pi.Ingredient)
                .ToListAsync();
        }

        public void Delete(Pizza item)
        {
            _dbContext.Pizzas.Remove(item);
        }
    }
}
