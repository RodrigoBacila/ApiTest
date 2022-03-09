namespace Domain.MathematicalOperations
{
    public class Division : MathematicalOperation
    {
        public Division(int firstValue, int secondValue) : base(firstValue, secondValue)
        {
        }

        public override int Execute()
        {
            return FirstValue / SecondValue;
        }
    }
}