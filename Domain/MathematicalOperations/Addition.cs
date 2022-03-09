namespace Domain.MathematicalOperations
{
    public class Addition : MathematicalOperation
    {
        public Addition(decimal firstValue, decimal secondValue) : base(firstValue, secondValue)
        {
        }

        public override decimal Execute()
        {
            return FirstValue + SecondValue;
        }
    }
}