using Newtonsoft.Json;

namespace ExchangeApiClient
{
    public class QuotationList
    {
        [JsonProperty("BRL")]
        public QuotationResponse Brl { get; set; }
        
        [JsonProperty("EUR")]
        public QuotationResponse Eur { get; set; }
    }
}
