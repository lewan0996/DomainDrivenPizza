using Domain.Menu.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Menu.EntityTypeConfigurations
{
    internal class IngredientEntityTypeConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.Property(i => i.IsSpicy).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(i => i.IsVegetarian).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(i => i.IsVegan).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
