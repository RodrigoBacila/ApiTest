using Microsoft.Extensions.DependencyInjection;

namespace ExchangeApiClient
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddExchangeApiClient(this IServiceCollection services)
        {
            services.AddScoped<IExchangeApiClient, ExchangeApiClient>();
            return services;
        }
    }
}
