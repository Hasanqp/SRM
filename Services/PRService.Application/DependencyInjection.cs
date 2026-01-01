using Microsoft.Extensions.DependencyInjection;

namespace PRService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            // MediatR / Validators
            return services;
        }

    }
}
