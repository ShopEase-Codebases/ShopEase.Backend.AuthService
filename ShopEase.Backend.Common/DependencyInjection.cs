using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ShopEase.Backend.Common.Application.Behaviours;
using ShopEase.Backend.Common.Messaging;
using ShopEase.Backend.Common.Messaging.Abstractions;
using System.Reflection;

namespace ShopEase.Backend.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddShopEaseCommon(this IServiceCollection services, Assembly handlerAssembly)
        {
            AddMessaging(services, handlerAssembly);
            AddBehaviours(services);

            return services;
        }

        private static IServiceCollection AddMessaging(this IServiceCollection services, Assembly handlerAssembly)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(handlerAssembly));
            services.AddScoped<IApiService, ApiService>(c =>
            {
                var mediator = c.GetRequiredService<IMediator>();
                return new ApiService(mediator);
            });

            return services;
        }

        private static IServiceCollection AddBehaviours(this IServiceCollection services) 
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));

            return services;
        }
    }
}
