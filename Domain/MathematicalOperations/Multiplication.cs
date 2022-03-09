namespace Domain.MathematicalOperations
{
    public class Multiplication : MathematicalOperation
    {
        public Multiplication(int firstValue, int secondValue) : base(firstValue, secondValue)
        {
        }

        public override int Execute()
        {
            return FirstValue * SecondValue;
        }
    }
}