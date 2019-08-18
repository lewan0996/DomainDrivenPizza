using Application.Menu.Commands;
using Application.Menu.Commands.Validations;
using Application.Shared.Behaviors;
using Autofac;
using FluentValidation;
using MediatR;

namespace Api.AutofacModules
{
    public class MediatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly)
                .AsImplementedInterfaces();
            
            builder.RegisterAssemblyTypes(typeof(CreateIngredientCommand).Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
            
            builder
                .RegisterAssemblyTypes(typeof(CreateIngredientCommandValidator).Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();

            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });

            builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(TransactionBehaviour<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}
