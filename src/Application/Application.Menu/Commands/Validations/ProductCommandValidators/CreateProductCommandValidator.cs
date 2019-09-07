﻿using Application.Menu.Commands.ProductCommands;
using Domain.Menu.ProductAggregate;
using FluentValidation;

namespace Application.Menu.Commands.Validations.ProductCommandValidators
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(c => c.Type)
                .NotEqual(ProductType.Pizza)
                .NotEqual(ProductType.Ingredient)
                .WithMessage("Pizzas and ingredients are managed by their own endpoints");

            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.AvailableQuantity).GreaterThanOrEqualTo(0);
            RuleFor(c => c.UnitPrice).GreaterThanOrEqualTo(0);
        }
    }
}
