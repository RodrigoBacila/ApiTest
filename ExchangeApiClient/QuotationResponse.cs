using Newtonsoft.Json;

namespace ExchangeApiClient
{
    public class QuotationResponse
    {
        public QuotationResponse()
        { }

        public QuotationResponse(string code, decimal value)
        {
            Code = code;
            Value = value;
        }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("value")]
        public decimal Value { get; set; }
    }
}
