using Domain.Menu.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Menu.EntityTypeConfigurations
{
    internal class PizzaEntityTypeConfiguration : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.Property(p => p.CrustType).HasConversion<string>();
        }
    }
}
