using Menu.Domain.ProductAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menu.Infrastructure.EntityTypeConfigurations
{
    internal class PizzaEntityTypeConfiguration : ProductEntityTypeConfiguration<Pizza>
    {
        public override void Configure(EntityTypeBuilder<Pizza> builder)
        {
            base.Configure(builder);

            //builder.HasData(SeedData.Pizzas); // there is a problem with OwnedTypes
        }
    }
}
