using System.Threading.Tasks;
using Basket.Domain.BasketAggregate;
using Microsoft.EntityFrameworkCore;
using Shared.Domain;
using Shared.Infrastructure;

namespace Basket.Infrastructure
{
    public class BasketRepository : Repository<CustomerBasket,BasketDbContext>
    {
        public BasketRepository(BasketDbContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork)
        {
        }

        public override Task<CustomerBasket> GetByIdAsync(int id)
        {
            return DbContext.Baskets
                .Include(b => b.Items)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
