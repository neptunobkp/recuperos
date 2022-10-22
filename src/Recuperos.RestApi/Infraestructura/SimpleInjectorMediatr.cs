using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MediatR;
using MediatR.Pipeline;
using Recuperos.Aplicacion.Comun.Comportamientos;
using SimpleInjector;

namespace Recuperos.RestApi.Infraestructura
{
    public static class ContainerExtension
    {
        public static Container BuildMediator(this Container container, params Assembly[] assemblies)
        {
            return BuildMediator(container, (IEnumerable<Assembly>)assemblies);
        }

        public static Container BuildMediator(this Container container, IEnumerable<Assembly> assemblies)
        {
            var allAssemblies = new List<Assembly> { typeof(IMediator).GetTypeInfo().Assembly };
            allAssemblies.AddRange(assemblies);

            container.RegisterSingleton<IMediator, Mediator>();
            container.Register(typeof(IRequestHandler<,>), allAssemblies);

            RegisterHandlers(container, typeof(INotificationHandler<>), assemblies.ToArray());
            RegisterHandlers(container, typeof(IRequestExceptionAction<,>), allAssemblies.ToArray());
            RegisterHandlers(container, typeof(IRequestExceptionHandler<,,>), allAssemblies.ToArray());
            // we have to do this because by default, generic type definitions (such as the Constrained Notification Handler) won't be registered
            var notificationHandlerTypes = container.GetTypesToRegister(typeof(INotificationHandler<>), assemblies, new TypesToRegisterOptions
            {
                IncludeGenericTypeDefinitions = true,
                IncludeComposites = false,
            });
            container.Register(typeof(INotificationHandler<>), notificationHandlerTypes);

            container.Collection.Register(typeof(IPipelineBehavior<,>), new[]
            {
                typeof(RequestExceptionProcessorBehavior<,>),
                typeof(RequestExceptionActionProcessorBehavior<,>),
                typeof(RequestPreProcessorBehavior<,>),
                typeof(RequestPostProcessorBehavior<,>),
                typeof(RequestValidationBehavior<,>)
            });

            container.Collection.Register(typeof(IRequestPreProcessor<>), new[]
            {
                typeof(RequestLogger<>)
            });

            container.Collection.Register(typeof(IRequestPostProcessor<,>), Enumerable.Empty<Type>());

            container.Register(() => new ServiceFactory(container.GetInstance), Lifestyle.Singleton);

            return container;
        }

        private static void RegisterHandlers(Container container, Type collectionType, Assembly[] assemblies)
        {
            // we have to do this because by default, generic type definitions (such as the Constrained Notification Handler) won't be registered
            var handlerTypes = container.GetTypesToRegister(collectionType, assemblies, new TypesToRegisterOptions
            {
                IncludeGenericTypeDefinitions = true,
                IncludeComposites = false,
            });

            container.Collection.Register(collectionType, handlerTypes);
        }
    }
}