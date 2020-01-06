using Delivery.Domain.SupplierAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Domain;

namespace Delivery.Infrastructure.EntityTypeConfigurations
{
    internal class SupplierEntityTypeConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(s => s.Status).HasConversion<string>();

            var seedData = new[] {new Supplier("Jan", "Kowalski"), new Supplier("Adam", "Nowak")};
            
            var idPropertyInfo = typeof(Entity).GetProperty(nameof(Entity.Id));

            // ReSharper disable once PossibleNullReferenceException
            idPropertyInfo.SetValue(seedData[0], 1);
            idPropertyInfo.SetValue(seedData[1], 2);

            builder.HasData(seedData);
            builder.Ignore(s => s.DomainEvents);
        }
    }
}
