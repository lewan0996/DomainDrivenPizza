using Application.Basket.Queries;
using Application.Menu.Queries;
using Autofac;
using Domain.Menu.ProductAggregate;
using Domain.SharedKernel;
using Infrastructure.Basket;
using Infrastructure.Menu;
using Infrastructure.Shared;
using Microsoft.Extensions.Configuration;

#pragma warning disable 1591

namespace Api.AutofacModules
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
                    c.Resolve<MenuDbContext>(), c.Resolve<BasketDbContext>())) //todo Use reflection to pass all dbcontexts
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Repository<Ingredient, MenuDbContext>>()
                .As<IRepository<Ingredient>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Repository<Pizza, MenuDbContext>>()
                .As<IRepository<Pizza>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Repository<Product, MenuDbContext>>()
                .As<IRepository<Product>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Repository<Domain.Basket.BasketAggregate.Basket, BasketDbContext>>()
                .As<IRepository<Domain.Basket.BasketAggregate.Basket>>()
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
