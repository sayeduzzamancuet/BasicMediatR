using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace BasicMediatR
{
    public static class BasicMediatR
    {
        public static IServiceCollection AddBasicMediatR(this IServiceCollection services, Assembly assembly)
        {
           
            // Register all handlers found in the given assembly
            var handlerTypes = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
                .ToList();
            foreach (var handlerType in handlerTypes)
            {
                // For each handler, find its interfaces
                var interfaces = handlerType.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>))
                    .ToList();

                foreach (var @interface in interfaces)
                {
                    // Register the handler in the DI container
                    services.AddTransient(@interface, handlerType);
                }
            }
            services.AddTransient<IMediatr, Mediatr>();
            return services;
        }
    }
}
