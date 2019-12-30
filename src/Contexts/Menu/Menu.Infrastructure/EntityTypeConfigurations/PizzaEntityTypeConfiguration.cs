using Menu.Domain.ProductAggregate;

namespace Menu.Infrastructure.EntityTypeConfigurations
{
    // ReSharper disable once UnusedType.Global
    internal class PizzaEntityTypeConfiguration : ProductEntityTypeConfiguration<Pizza>
    {
        //public override void Configure(EntityTypeBuilder<Pizza> builder)
        //{
        //    base.Configure(builder);

        //    //builder.HasData(SeedData.Pizzas); // there is a problem with OwnedTypes
        //}
    }
}
