using System.Reflection;
using API.Contexts.Basket.Controllers;
using Basket.Application.AddItemToBasketApplication;
using Menu.Application.ProductApplications.CreateProductApplication;
using Ordering.Application.CreateOrderApplication;
using Shared.IntegrationEvents.Ordering;

#pragma warning disable 1591

namespace API.Infrastructure
{
    public static class AssemblyExtensions
    {
        public static Assembly[] GetMappingAssemblies() //todo find better way
        {
            return new[]
            {
                typeof(BasketController).Assembly,
                typeof(CreateOrderCommand).Assembly,
                typeof(CreateProductCommand).Assembly,
                typeof(AddItemToBasketCommand).Assembly,
                typeof(NewOrderCreatedIntegrationEvent).Assembly
            };
        }

        public static Assembly[] GetCommandHandlerAssemblies()
        {
            return new[]
            {
                typeof(CreateOrderCommand).Assembly,
                typeof(CreateProductCommand).Assembly,
                typeof(AddItemToBasketCommand).Assembly
            };
        }
    }
}