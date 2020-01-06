using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain.OrderAggregate;

namespace Ordering.Infrastructure
{
    public class OrderingDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        // ReSharper disable once SuggestBaseTypeForParameter
        public OrderingDbContext(DbContextOptions<OrderingDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Ordering");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
