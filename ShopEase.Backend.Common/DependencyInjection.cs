using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ShopEase.Backend.Common.Messaging;
using ShopEase.Backend.Common.Messaging.Abstractions;
using System.Reflection;

namespace ShopEase.Backend.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCQRSMessaging(this IServiceCollection services, Assembly handlerAssembly)
        {
            // Adding Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(handlerAssembly));
            services.AddScoped<IApiService, ApiService>(c =>
            {
                var mediator = c.GetRequiredService<IMediator>();
                return new ApiService(mediator);
            });

            return services;
        }
    }
}
