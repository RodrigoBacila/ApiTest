using Newtonsoft.Json;

namespace ExchangeApiClient
{
    public class QuotationList
    {
        [JsonProperty("BRL")]
        public Quotation Brl { get; set; }
        
        [JsonProperty("EUR")]
        public Quotation Eur { get; set; }
    }
}
