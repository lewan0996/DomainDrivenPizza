using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basket.Infrastructure.EntityTypeConfigurations
{
    internal class BasketEntityTypeConfiguration : IEntityTypeConfiguration<Domain.BasketAggregate.CustomerBasket>
    {
        public void Configure(EntityTypeBuilder<Domain.BasketAggregate.CustomerBasket> builder)
        {
            builder.HasMany(b => b.Items)
                .WithOne()
                .HasForeignKey(bi => bi.BasketId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Ignore(b => b.DomainEvents);
        }
    }
}
