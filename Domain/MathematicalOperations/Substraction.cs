namespace Domain.MathematicalOperations
{
    public class Subtraction : MathematicalOperation
    {
        public Subtraction(decimal firstValue, decimal secondValue) : base(firstValue, secondValue)
        {
        }

        public override decimal Execute()
        {
            return FirstValue - SecondValue;
        }
    }
}