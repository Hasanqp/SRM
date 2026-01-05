using Microsoft.Extensions.DependencyInjection;
using RFQService.Application.Abstractions.Persistence;
using RFQService.Infrastructure.Persistence.Repositories;

namespace RFQService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrstructure(this IServiceCollection services)
        {
            services.AddSingleton<IRFQRepository, InMemoryRFQRepository>();

            return services;
        }
    }
}
