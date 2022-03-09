namespace Domain.MathematicalOperations
{
    public class Substraction : MathematicalOperation
    {
        public Substraction(int firstValue, int secondValue) : base(firstValue, secondValue)
        {
        }

        public override int Execute()
        {
            return FirstValue - SecondValue;
        }
    }
}