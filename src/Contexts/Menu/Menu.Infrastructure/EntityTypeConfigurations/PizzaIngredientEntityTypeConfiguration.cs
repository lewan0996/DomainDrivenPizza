﻿using Menu.Domain.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menu.Infrastructure.EntityTypeConfigurations
{
    public class PizzaIngredientEntityTypeConfiguration : IEntityTypeConfiguration<PizzaIngredient>
    {
        public void Configure(EntityTypeBuilder<PizzaIngredient> builder)
        {
            builder.HasKey(pi => new { pi.PizzaId, pi.IngredientId });
            builder.HasOne(pi => pi.Pizza)
                .WithMany(p => p.Ingredients)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pi => pi.Ingredient)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
