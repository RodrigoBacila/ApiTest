using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects
{
    public class CurrentQuotation
    {
        public CurrentQuotation(string code, decimal rate)
        {
            Code = code;
            Rate = rate;
        }

        [Key]
        public string Code { get; private set; }
        public decimal Rate { get; private set; }

        public void UpdateRate(decimal newRate)
        {
            Rate = newRate;
        }
    }
}
