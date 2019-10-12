using Domain.Basket.BasketAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Basket.EntityTypeConfigurations
{
    internal class BasketItemEntityTypeConfiguration : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder.Property(bi => bi.ProductId).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(bi => bi.Quantity).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
