﻿using MediatR;
using Menu.Application.Queries.DTO;

namespace Menu.Application.IngredientApplications.CreateIngredientApplication
{
    public class CreateIngredientCommand : IRequest<IngredientDTO>
    {
        public string Name { get; }
        public string Description { get; }
        public float UnitPrice { get; }
        public int AvailableQuantity { get; }
        public bool IsSpicy { get; }
        public bool  IsVegetarian { get; }
        public bool IsVegan { get; }

        public CreateIngredientCommand(string name, string description, float unitPrice, int availableQuantity,
            bool isSpicy, bool isVegetarian, bool isVegan)
        {
            IsSpicy = isSpicy;
            IsVegetarian = isVegetarian;
            IsVegan = isVegan;
            Name = name;
            Description = description;
            UnitPrice = unitPrice;
            AvailableQuantity = availableQuantity;
        }
    }
}
