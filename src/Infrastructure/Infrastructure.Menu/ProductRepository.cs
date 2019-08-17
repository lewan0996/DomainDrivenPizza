using Domain.Menu.ProductAggregate;
using Infrastructure.Shared;

namespace Infrastructure.Menu
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        // ReSharper disable once SuggestBaseTypeForParameter
        public ProductRepository(MenuDbContext context): base(context)
        {
        }
    }
}
