namespace ExchangeApiClient
{
    public interface IExchangeApiClient
    {
        Task<IList<Quotation>?> GetCurrentExchangeRatesAsync();
    }
}
