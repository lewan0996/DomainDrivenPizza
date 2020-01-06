using System.Linq;
using Autofac;
using Basket.Application.Queries;
using Basket.Domain.BasketAggregate;
using Basket.Infrastructure;
using Delivery.Application.Queries;
using Delivery.Domain.Services;
using Delivery.Domain.SupplierAggregate;
using MediatR;
using Menu.Application.Queries;
using Menu.Domain.ProductAggregate;
using Menu.Infrastructure;
using Menu.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ordering.Application.Queries;
using Ordering.Domain.OrderAggregate;
using Shared.Domain;
using Shared.Infrastructure;
using Module = Autofac.Module;

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
            builder.Register(c => new EFUnitOfWork(c.Resolve<IMediator>(),
                    GetAllDbContexts(c)))
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

            builder.RegisterType<Ordering.Infrastructure.OrderRepository>()
                .As<IRepository<Order>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Delivery.Infrastructure.OrderRepository>()
                .As<IRepository<Delivery.Domain.OrderAggregate.Order>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Delivery.Infrastructure.SupplierRepository>()
                .As<ISupplierRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Delivery.Infrastructure.SupplierRepository>()
                .As<IRepository<Supplier>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<OrderDeliveryService>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductQueries>()
                .AsSelf()
                .WithParameter(
                    new TypedParameter(
                        typeof(string),
                        _configuration.GetConnectionString("SqlServer")
                    )
                )
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

            builder.RegisterType<OrderingQueries>()
                .AsSelf()
                .WithParameter(
                    new TypedParameter(
                        typeof(string),
                        _configuration.GetConnectionString("SqlServer")
                    )
                )
                .InstancePerLifetimeScope();


            builder.RegisterType<DeliveryQueries>()
                .AsSelf()
                .WithParameter(
                    new TypedParameter(
                        typeof(string),
                        _configuration.GetConnectionString("SqlServer")
                    )
                )
                .InstancePerLifetimeScope();
        }

        private DbContext[] GetAllDbContexts(IComponentContext c)
        {
            var dbContextTypes = AssemblyExtensions.GetDbContextTypes();

            return dbContextTypes.Select(t => (DbContext)c.Resolve(t)).ToArray();
        }
    }
}
