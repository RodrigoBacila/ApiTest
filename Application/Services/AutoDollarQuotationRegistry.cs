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

            if (currentQuotation == null)
            {
                System.Diagnostics.Debug.WriteLine("Failed to get current quotation."); // Aqui se poderia usar um logger ou criar um retorno personalizado para o front, usando um objeto de resultado que encapsule o valor (ex: OperationResult com erro)

                return;
            }

            var quotations = new List<Quotation>(currentQuotation.Select(quotation => new Quotation(quotation.Code, quotation.Value)));

            await exchangeRatesRepository.RegisterLatestExchangeRatesAsync(quotations.Select(quot => new QuotationDto(quot.Code, quot.Value)).ToList());

            BackgroundJob.Schedule<AutoDollarQuotationRegistry>(job => job.RegisterCurrentQuotationAsync(), TimeSpan.FromSeconds(15));
        }
    }
}
