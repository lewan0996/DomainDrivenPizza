﻿using FluentValidation;

namespace Menu.Application.PizzaApplications.UpdatePizzaApplication
{
    public class UpdatePizzaCommandValidator : AbstractValidator<UpdatePizzaCommand>
    {
        public UpdatePizzaCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().When(c => c.Name != null);
            RuleFor(c => c.Description).NotEmpty().When(c => c.Description != null);
            RuleFor(c => c.UnitPrice).GreaterThanOrEqualTo(0).When(c => c.UnitPrice.HasValue);
        }
    }
}
