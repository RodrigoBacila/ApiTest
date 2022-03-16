using Application.DataTransferObjects;
using Application.Interfaces;
using ExchangeApiClient;
using Hangfire;

namespace Application.Services
{
    public class AutoDollarQuotationRegistry
    {
        private readonly IExchangeApiClient exchangeApiClient;
        private readonly IExchangeRatesRepository exchangeRatesRepository;

        public AutoDollarQuotationRegistry(IExchangeApiClient exchangeApiClient, IExchangeRatesRepository exchangeRatesRepository)
        {
            this.exchangeApiClient = exchangeApiClient;
            this.exchangeRatesRepository = exchangeRatesRepository;
        }

        public async Task RegisterCurrentQuotationAsync()
        {
            var quotationResponseList = await exchangeApiClient.GetCurrentExchangeRatesAsync();

            if (!quotationResponseList?.Any() ?? true) // This is just sample code. The best approach would be to have a logging system and/or implement a callback with a result object containing the error message (especially with a frontend integration)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{DateTime.Now.ToShortTimeString()} - Failed to get current quotation.");
                Console.ForegroundColor = ConsoleColor.Gray;

                BackgroundJob.Schedule<AutoDollarQuotationRegistry>(job => job.RegisterCurrentQuotationAsync(), TimeSpan.FromSeconds(60));

                return;
            }

            await exchangeRatesRepository.RegisterLatestExchangeRatesAsync(quotationResponseList.Select(quot => new CurrentQuotation(quot.Code, quot.Value)).ToList());

            BackgroundJob.Schedule<AutoDollarQuotationRegistry>(job => job.RegisterCurrentQuotationAsync(), TimeSpan.FromSeconds(15));
        }
    }
}
