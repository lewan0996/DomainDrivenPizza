using System.Reflection;
using Delivery.Domain.OrderAggregate;
using Delivery.Domain.SupplierAggregate;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Infrastructure
{
    public class DeliveryDbContext : DbContext
    {
        // ReSharper disable once SuggestBaseTypeForParameter
        public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Delivery");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
