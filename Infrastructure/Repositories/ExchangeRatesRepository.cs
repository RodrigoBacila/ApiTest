using Application.DataTransferObjects;
using Application.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ExchangeRatesRepository : IExchangeRatesRepository
    {
        private ScaffoldContext context;

        public ExchangeRatesRepository(ScaffoldContext context)
        {
            this.context = context;
        }

        public async Task RegisterLatestExchangeRatesAsync(IList<CurrentQuotation> quotations)
        {
            foreach (var quotation in quotations)
            {
                var existentRegistry = await context.CurrentQuotations.FirstOrDefaultAsync(quot => quot.Code == quotation.Code);

                if (existentRegistry == null)
                {
                    await context.CurrentQuotations.AddAsync(quotation);
                    continue;
                }

                context.CurrentQuotations.Remove(existentRegistry);
                await context.CurrentQuotations.AddAsync(quotation);
            }

            await context.SaveChangesAsync();
        }
    }
}
