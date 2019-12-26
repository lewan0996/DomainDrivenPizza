using System.Reflection;
using Basket.Domain.BasketAggregate;
using Microsoft.EntityFrameworkCore;

namespace Basket.Infrastructure
{
    public class BasketDbContext : DbContext
    {
        // ReSharper disable once SuggestBaseTypeForParameter
        public BasketDbContext(DbContextOptions<BasketDbContext> options) : base(options)
        {
        }

        public DbSet<CustomerBasket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Basket");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
