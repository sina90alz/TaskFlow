using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TaskFlow.Application.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {       
            // Registers all MediatR handlers in this assembly
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            return services;
        }
    }
}
