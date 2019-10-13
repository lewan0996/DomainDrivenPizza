using System.IO;
using System.Reflection;
using Domain.Basket.BasketAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Basket
{
    public class BasketDbContext : DbContext
    {
        public BasketDbContext(DbContextOptions<BasketDbContext> options) : base(options)
        {
        }

        public DbSet<Domain.Basket.BasketAggregate.Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Basket");
            modelBuilder.ForSqlServerUseSequenceHiLo("BasketHiLoSequence");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

    internal class BasketContextContextFactory : IDesignTimeDbContextFactory<BasketDbContext>
    {
        public BasketDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
                    
            var builder = new DbContextOptionsBuilder<BasketDbContext>();
            
            var connectionString = configuration.GetConnectionString("SqlServer");
            builder.UseSqlServer(connectionString);
            
            return new BasketDbContext(builder.Options);
        }
    }
}
