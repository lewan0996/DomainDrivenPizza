using Menu.Domain.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Menu.Infrastructure
{
    public class MenuDbContext : DbContext
    {
        // ReSharper disable once SuggestBaseTypeForParameter
        public MenuDbContext(DbContextOptions<MenuDbContext> options) : base(options)
        {
        }

        //public DbSet<Product> Products { get; set; } // Lack of TPT or TPC prevents from including base type to the model
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Menu");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
