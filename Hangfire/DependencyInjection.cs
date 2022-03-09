using Hangfire.SqlServer;
using Microsoft.Extensions.DependencyInjection;

namespace Hangfire
{
    public static class DependencyInjection
    {
        public static IServiceCollection UseHangfire(this IServiceCollection services)
        {
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(@"Server=.\SQLEXPRESS; Database=Hangfire; Integrated Security=True",
                    new SqlServerStorageOptions
                    {
                        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                        QueuePollInterval = TimeSpan.Zero,
                        UseRecommendedIsolationLevel = true,
                        DisableGlobalLocks = true
                    }));

            services.AddHangfireServer();

            return services;
        }
    }
}
