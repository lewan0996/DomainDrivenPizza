using Domain.Menu.ProductAggregate;
using Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Menu
{
    public class ProductRepository : Repository<Product>
    {
        // ReSharper disable once SuggestBaseTypeForParameter
        public ProductRepository(MenuDbContext dbContext) : base(dbContext)
        {
        }
    }
}
