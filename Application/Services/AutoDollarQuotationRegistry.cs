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
            var currentQuotation = await exchangeApiClient.GetCurrentExchangeRatesAsync();

            if (!currentQuotation?.Any() ?? true) // This is just sample code. The best approach would be to have a logging system and/or implement a callback with a result object containing the error message (especially with a frontend integration)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{DateTime.Now.ToShortTimeString()} - Failed to get current quotation.");
                Console.ForegroundColor = ConsoleColor.Gray;

                BackgroundJob.Schedule<AutoDollarQuotationRegistry>(job => job.RegisterCurrentQuotationAsync(), TimeSpan.FromSeconds(60));

                return;
            }

            var quotations = new List<QuotationResponse>(currentQuotation.Select(quotation => new QuotationResponse(quotation.Code, quotation.Value)));

            await exchangeRatesRepository.RegisterLatestExchangeRatesAsync(quotations.Select(quot => new CurrentQuotation(quot.Code, quot.Value)).ToList());

            BackgroundJob.Schedule<AutoDollarQuotationRegistry>(job => job.RegisterCurrentQuotationAsync(), TimeSpan.FromSeconds(15));
        }
    }
}
