using Newtonsoft.Json;
using RestSharp;

namespace ExchangeApiClient
{
    public class ExchangeApiClient : IExchangeApiClient
    {
        private const string AccessKey = "8b1DKSljTWQXh1oWrH1tgNkD2YxB4u8uDwvmng9j";

        private readonly RestClient restClient;

        public ExchangeApiClient()
        {
            var baseUrl = "https://api.currencyapi.com/v3/latest";

            restClient = new RestClient(baseUrl);
            restClient.AddDefaultParameter(Parameter.CreateParameter("apikey", AccessKey, ParameterType.QueryString));
        }

        public async Task<IList<QuotationResponse>?> GetCurrentExchangeRatesAsync()
        {
            var request = new RestRequest()
                .AddQueryParameter("base_currency", "USD")
                .AddQueryParameter("currencies", string.Join(",", new string[] { "BRL", "EUR" }));

            var response = await restClient.ExecuteAsync(request);

            if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
            {
                var rates = JsonConvert.DeserializeObject<CurrentExchangeRates>(response.Content);

                if (rates == null)
                {
                    return new List<QuotationResponse>();
                }

                return new List<QuotationResponse>()
                {
                    rates.Data.Brl,
                    rates.Data.Eur
                };
            }

            throw new HttpRequestException("Error trying to fetch current exchange rates.");
        }
    }
}
