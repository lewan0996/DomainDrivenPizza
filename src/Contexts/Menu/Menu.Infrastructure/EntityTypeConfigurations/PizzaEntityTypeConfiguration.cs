using Menu.Domain.ProductAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menu.Infrastructure.EntityTypeConfigurations
{
    // ReSharper disable once UnusedType.Global
    internal class PizzaEntityTypeConfiguration : ProductEntityTypeConfiguration<Pizza>
    {
        public override void Configure(EntityTypeBuilder<Pizza> builder)
        {
            base.Configure(builder);

            builder.Ignore(p => p.AvailableQuantity);
            builder.Ignore(p => p.DomainEvents);

            //builder.HasData(SeedData.Pizzas); // there is a problem with OwnedTypes
        }
    }
}
