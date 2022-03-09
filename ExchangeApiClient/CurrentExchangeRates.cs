using Newtonsoft.Json;

namespace ExchangeApiClient
{
    public class CurrentExchangeRates
    {
        public CurrentExchangeRates()
        { }

        [JsonProperty("meta")]
        public dynamic Meta { get; set; }


        [JsonProperty("data")]
        public QuotationList Data { get; set; }
    }
}
