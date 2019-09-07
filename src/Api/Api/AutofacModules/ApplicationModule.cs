using Application.Menu.Queries;
using Autofac;
using Domain.Menu.ProductAggregate;
using Domain.SharedKernel;
using Infrastructure.Menu;
using Infrastructure.Shared;
#pragma warning disable 1591

namespace Api.AutofacModules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new EFUnitOfWork(c.Resolve<MenuDbContext>())) //todo Use reflection to pass all dbcontexts
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<IngredientRepository>()
                .As(typeof(IRepository<Ingredient>))
                .InstancePerLifetimeScope();

            builder.RegisterType<PizzaRepository>()
                .As(typeof(IRepository<Pizza>))
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductRepository>()
                .As(typeof(IRepository<Product>))
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductQueries>()
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}
