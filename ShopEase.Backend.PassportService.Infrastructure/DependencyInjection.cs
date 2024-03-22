using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopEase.Backend.PassportService.Infrastructure.Helpers;

namespace ShopEase.Backend.PassportService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHelpers(configuration);

            return services;
        }

        private static IServiceCollection AddHelpers(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            return services;
        }
    }
}
