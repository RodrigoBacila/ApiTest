namespace ExchangeApiClient
{
    public interface IExchangeApiClient
    {
        Task<IList<QuotationResponse>?> GetCurrentExchangeRatesAsync();
    }
}
