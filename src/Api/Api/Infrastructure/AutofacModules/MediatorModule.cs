using Autofac;
using FluentValidation;
using MediatR;
using Menu.Application.EventHandlers;
using Ordering.Application.CreateOrderApplication;
using Ordering.Application.EventHandlers;
using Shared.Application.Behaviors;
using Shared.Infrastructure;

#pragma warning disable 1591

namespace API.Infrastructure.AutofacModules
{
    public class MediatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly)
                .AsImplementedInterfaces();

            // Register all the Command handler classes (they implement IRequestHandler) in assembly holding the Commands
            builder.RegisterAssemblyTypes(AssemblyExtensions.GetSolutionAssemblies())
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(CreateOrderCommandHandler).Assembly) // todo remove after implementing at least one Ordering endpoint
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            // Register the EventHandler classes (they implement INotificationHandler<>) in assembly holding the Domain Events

            //builder.RegisterAssemblyTypes(AssemblyExtensions.GetSolutionAssemblies())
            //    .AsClosedTypesOf(typeof(INotificationHandler<>));

            builder.RegisterAssemblyTypes(typeof(BasketCheckedOutEventHandler).Assembly) // todo remove after implementing at least one Ordering endpoint
                .AsClosedTypesOf(typeof(INotificationHandler<>));

            builder.RegisterAssemblyTypes(typeof(NewOrderCreatedEventHandler).Assembly) // todo remove after implementing at least one Ordering endpoint
                .AsClosedTypesOf(typeof(INotificationHandler<>));

            // Register the Command's Validators (Validators based on FluentValidation library)
            builder
                .RegisterAssemblyTypes(AssemblyExtensions.GetSolutionAssemblies())
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();

            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => componentContext.TryResolve(t, out var o) ? o : null;
            });

            builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(TransactionBehaviour<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}
