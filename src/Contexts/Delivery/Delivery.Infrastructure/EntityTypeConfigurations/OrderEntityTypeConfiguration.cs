using Delivery.Domain.OrderAggregate;
using Delivery.Domain.SupplierAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivery.Infrastructure.EntityTypeConfigurations
{
    // ReSharper disable once UnusedType.Global
    internal class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasMany(o => o.Items)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Supplier>()
                .WithMany()
                .HasForeignKey(o => o.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.OwnsOne(o => o.Client);
            builder.OwnsOne(o => o.Address);

            builder.Property(o => o.Status).HasConversion<string>();
            builder.Ignore(o => o.DomainEvents);
        }
    }
}
