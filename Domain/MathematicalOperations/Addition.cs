namespace Domain.MathematicalOperations
{
    public class Addition : MathematicalOperation
    {
        public Addition(int firstValue, int secondValue) : base(firstValue, secondValue)
        {
        }

        public override int Execute()
        {
            return FirstValue + SecondValue;
        }
    }
}