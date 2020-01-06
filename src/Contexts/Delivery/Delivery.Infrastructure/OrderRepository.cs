using System.Threading.Tasks;
using Delivery.Domain.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Shared.Domain;
using Shared.Infrastructure;

namespace Delivery.Infrastructure
{
    public class OrderRepository : Repository<Order,DeliveryDbContext>
    {
        public OrderRepository(DeliveryDbContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork)
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
