using Microsoft.Extensions.DependencyInjection;
using PRService.Application.Abstractions.Persistence;
using PRService.Infrastructure.Persistence.Repositories;

namespace PRService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IPurchaseRequestRepository,
                InMemoryPurchaseRequestRepository>();

            return services;
        }
    }
}
