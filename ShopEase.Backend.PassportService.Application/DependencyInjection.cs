using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ShopEase.Backend.PassportService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(AssemblyReference.Assembly, includeInternalTypes: true);

            return services;
        }
    }
}
