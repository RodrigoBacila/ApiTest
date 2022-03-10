using Application.DataTransferObjects;

namespace Application.Interfaces
{
    public interface IExchangeRatesRepository
    {
        Task RegisterLatestExchangeRatesAsync(IList<CurrentQuotation> quotations);
    }
}
