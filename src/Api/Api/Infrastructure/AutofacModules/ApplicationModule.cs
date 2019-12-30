﻿using Autofac;
using Basket.Application.Queries;
using Basket.Domain.BasketAggregate;
using Basket.Infrastructure;
using Menu.Application.Queries;
using Menu.Domain.ProductAggregate;
using Menu.Infrastructure;
using Menu.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Ordering.Domain.OrderAggregate;
using Ordering.Infrastructure;
using Shared.Domain;
using Shared.Infrastructure;

#pragma warning disable 1591

namespace API.Infrastructure.AutofacModules
{
    public class ApplicationModule : Module
    {
        private readonly IConfiguration _configuration;

        public ApplicationModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new EFUnitOfWork(
                    c.Resolve<MenuDbContext>(), c.Resolve<BasketDbContext>(),
                    c.Resolve<OrderingDbContext>())) //todo Use reflection to pass all dbcontexts
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Repository<Ingredient, MenuDbContext>>()
                .As<IRepository<Ingredient>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PizzaRepository>()
                .As<IRepository<Pizza>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductRepository>()
                .As<IRepository<Product>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BasketRepository>()
                .As<IRepository<CustomerBasket>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Repository<Order, OrderingDbContext>>()
                .As<IRepository<Order>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductQueries>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<BasketQueries>()
                .AsSelf()
                .WithParameter(
                    new TypedParameter(
                        typeof(string),
                        _configuration.GetConnectionString("SqlServer")
                        )
                    )
                .InstancePerLifetimeScope();
        }
    }
}