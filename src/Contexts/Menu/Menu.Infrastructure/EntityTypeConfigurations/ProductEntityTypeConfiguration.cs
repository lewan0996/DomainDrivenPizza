using Menu.Domain.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menu.Infrastructure.EntityTypeConfigurations
{
    internal class ProductEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T:Product
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.OwnsOne(p => p.Name, ba =>
            {
                ba.Property(pn => pn.Value).HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(255);
            });

            builder.OwnsOne(p => p.Description, ba =>
            {
                ba.Property(pd => pd.Value).HasColumnName("Description")
                    .IsRequired()
                    .HasMaxLength(255);
            });

            builder.Property(p => p.Type).HasConversion<string>();
            builder.HasKey(p => p.Id);
        }
    }
}
