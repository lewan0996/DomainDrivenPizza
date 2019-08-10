using Domain.Menu.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Menu.EntityTypeConfigurations
{
    internal class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.OwnsOne(p => p.Name, ba =>
            {
                ba.Property(pn => pn.Value).HasColumnName("Name");
            });
            builder.OwnsOne(p => p.Description, ba =>
            {
                ba.Property(pd => pd.Value).HasColumnName("Description");
            });
            builder.Property(p => p.Type).HasConversion<string>();
            builder.HasKey(p => p.Id);
            builder.Property(p => p.AvailableQuantity);
            builder.Property(p => p.UnitPrice);
        }
    }
}
