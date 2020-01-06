using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain.OrderAggregate;
using Shared.Domain;
using Shared.Infrastructure;

namespace Ordering.Infrastructure
{
    public class OrderRepository : Repository<Order,OrderingDbContext>
    {
        public OrderRepository(OrderingDbContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork)
        {
        }

        public override Task<Order> GetByIdAsync(int id)
        {
            return DbContext.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
