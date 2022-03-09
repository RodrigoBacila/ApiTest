namespace Application.DataTransferObjects
{
    public class QuotationDto
    {
        public QuotationDto()
        { }

        public QuotationDto(string code, decimal value)
        {
            Code = code;
            Value = value;
        }

        public string Code { get; set; }
        public decimal Value { get; set; }
    }
}
