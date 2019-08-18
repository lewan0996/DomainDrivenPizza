using Autofac;
using Domain.Menu.ProductAggregate;
using Domain.SharedKernel;
using Infrastructure.Menu;
using Infrastructure.Shared;

namespace Api.AutofacModules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductRepository>()
                .As<IProductRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new EFUnitOfWork(c.Resolve<MenuDbContext>())) //todo Use reflection to pass all dbcontexts
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();
        }
    }
}
