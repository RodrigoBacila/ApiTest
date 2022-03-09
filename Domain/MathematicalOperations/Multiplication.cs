namespace Domain.MathematicalOperations
{
    public class Multiplication : MathematicalOperation
    {
        public Multiplication(decimal firstValue, decimal secondValue) : base(firstValue, secondValue)
        {
        }

        public override decimal Execute()
        {
            return FirstValue * SecondValue;
        }
    }
}