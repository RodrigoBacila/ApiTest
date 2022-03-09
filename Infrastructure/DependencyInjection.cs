using Application.Interfaces;
using Infrastructure.Context;
using Infrastructure.Queries;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IExchangeRatesRepository, ExchangeRatesRepository>();
            services.AddScoped<IExchangeRatesQueries, ExchangeRatesQueries>();
            services.AddScoped<ScaffoldContext>();

            services.AddDbContext<ScaffoldContext>(options => options.UseSqlServer(@"Server=.\SQLEXPRESS; Database=ExchangeRates; Integrated Security=True"));

            return services;
        }
    }
}
