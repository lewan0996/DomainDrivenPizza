﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.OrderAggregate;

namespace Ordering.Infrastructure.EntityTypeConfigurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(o => o.Items)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.OwnsOne(o => o.Address);
            builder.OwnsOne(o => o.Client);

            builder.Property(o => o.Status).HasConversion<string>();
            builder.Ignore(o => o.DomainEvents);
        }
    }
}
