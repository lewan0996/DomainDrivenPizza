using System;
using System.Linq;
using System.Reflection;
using API.Contexts.Basket.Controllers;
using Basket.Application.AddItemToBasketApplication;
using Delivery.Application.FinishDeliveryApplication;
using Delivery.Application.IntegrationEventHandlers;
using Menu.Application.IntegrationEventHandlers;
using Menu.Application.ProductApplications.CreateProductApplication;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.CreateOrderApplication;
using Ordering.Application.IntegrationEventHandlers;
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
                typeof(AddItemToBasketCommand).Assembly,
                typeof(FinishDeliveryCommand).Assembly
            };
        }

        public static Assembly[] GetEventHandlerAssemblies()
        {
            return new[]
            {
                typeof(BasketCheckedOutIntegrationEventHandler).Assembly,
                typeof(NewOrderCreatedIntegrationEventHandler).Assembly,
                typeof(OrderShippedIntegrationEventHandler).Assembly
            };
        }

        public static Type[] GetDbContextTypes()
        {
            return Assembly.GetEntryAssembly()?.GetReferencedAssemblies()
                .Select(Assembly.Load)
                .SelectMany(a => a.GetTypes())
                .Where(t => t.IsSubclassOf(typeof(DbContext))).ToArray();
        }
    }
}