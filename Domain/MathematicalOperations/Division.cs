namespace Domain.MathematicalOperations
{
    public class Division : MathematicalOperation
    {
        public Division(decimal firstValue, decimal secondValue) : base(firstValue, secondValue)
        {
        }

        public override decimal Execute()
        {
            return decimal.Divide(FirstValue, SecondValue);
        }
    }
}