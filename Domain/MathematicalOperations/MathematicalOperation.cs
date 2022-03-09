using Ardalis.GuardClauses;

namespace Domain.MathematicalOperations
{
    public abstract class MathematicalOperation
    {
        private int firstValue;
        private int secondValue;

        protected MathematicalOperation(int firstValue, int secondValue)
        {
            FirstValue = firstValue;
            SecondValue = secondValue;
        }

        protected int FirstValue
        {
            get => firstValue; set
            {
                Guard.Against.Null(value, nameof(value));
                firstValue = value;
            }
        }

        protected int SecondValue
        {
            get => secondValue; set
            {
                Guard.Against.Null(value, nameof(value));
                secondValue = value;
            }
        }

        public abstract int Execute();
    }
}