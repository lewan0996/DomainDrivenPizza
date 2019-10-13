using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Basket.EntityTypeConfigurations
{
    internal class BasketEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Basket.BasketAggregate.Basket>
    {
        public void Configure(EntityTypeBuilder<Domain.Basket.BasketAggregate.Basket> builder)
        {
            builder.HasMany(b => b.Items)
                .WithOne()
                .HasForeignKey(bi => bi.BasketId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
