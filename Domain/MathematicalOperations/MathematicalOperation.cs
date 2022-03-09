using Ardalis.GuardClauses;

namespace Domain.MathematicalOperations
{
    public abstract class MathematicalOperation
    {
        protected decimal firstValue;
        protected decimal secondValue;

        protected MathematicalOperation(decimal firstValue, decimal secondValue)
        {
            FirstValue = firstValue;
            SecondValue = secondValue;
        }

        protected decimal FirstValue
        {
            get => firstValue; set
            {
                Guard.Against.Null(value, nameof(value));
                firstValue = value;
            }
        }

        protected decimal SecondValue
        {
            get => secondValue; set
            {
                Guard.Against.Null(value, nameof(value));
                secondValue = value;
            }
        }

        public abstract decimal Execute();
    }
}