using Application.Menu.Queries;
using Autofac;
using Domain.Basket.BasketAggregate;
using Domain.Menu.ProductAggregate;
using Domain.SharedKernel;
using Infrastructure.Basket;
using Infrastructure.Menu;
using Infrastructure.Shared;

#pragma warning disable 1591

namespace Api.AutofacModules
{
    public class ApplicationModule : Module
    {
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

            builder.RegisterType<Repository<Basket, BasketDbContext>>()
                .As<IRepository<Basket>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductQueries>()
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}
