using Newtonsoft.Json;

namespace ExchangeApiClient
{
    public class Quotation
    {
        public Quotation()
        { }

        public Quotation(string code, decimal value)
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
