﻿using Menu.Domain.ProductAggregate;

namespace Menu.Infrastructure.EntityTypeConfigurations
{
    // ReSharper disable once UnusedType.Global
    internal class IngredientEntityTypeConfiguration : ProductEntityTypeConfiguration<Ingredient>
    {
        //public override void Configure(EntityTypeBuilder<Ingredient> builder)
        //{
        //    base.Configure(builder);

        //    //builder.HasData(SeedData.Ingredients); // there is a problem with OwnedTypes
        //}
    }
}