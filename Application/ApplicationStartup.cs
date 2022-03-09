using Application.Services;
using Hangfire;

namespace Application
{
    public static class ApplicationStartup
    {
        private static bool initialized = false;

        public static void StartRecurringHangfireTasks()
        {
            if (!initialized)
            {
                BackgroundJob.Schedule<AutoDollarQuotationRegistry>(job => job.RegisterCurrentQuotationAsync(), TimeSpan.FromSeconds(60));
                initialized = true;
            }
        }
    }
}
