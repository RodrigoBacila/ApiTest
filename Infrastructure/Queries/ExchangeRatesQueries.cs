using Application.DataTransferObjects;
using Application.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries
{
    public class ExchangeRatesQueries : IExchangeRatesQueries
    {
        private ScaffoldContext context;

        public ExchangeRatesQueries(ScaffoldContext context)
        {
            this.context = context;
        }

        public async Task<CurrentQuotation> GetLatestExchangeRateAsync(string code)
        {
            return await context.CurrentQuotations.FirstOrDefaultAsync(quot => quot.Code == code);
        }
    }
}
