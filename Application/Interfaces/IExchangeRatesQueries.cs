using Application.DataTransferObjects;

namespace Application.Interfaces
{
    public interface IExchangeRatesQueries
    {
        Task<CurrentQuotation> GetLatestExchangeRateAsync(string code);
    }
}
