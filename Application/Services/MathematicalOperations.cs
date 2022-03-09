using Application.Interfaces;
using Domain.MathematicalOperations;

namespace Application.Services
{
    public class MathematicalOperations : IMathematicalOperations
    {
        
        public decimal Add(decimal firstValue, decimal secondValue)
        {
            return new Addition(firstValue, secondValue).Execute();
        }

        public decimal Divide(decimal firstValue, decimal secondValue)
        {
            return new Division(firstValue, secondValue).Execute();
        }

        public decimal Multiply(decimal firstValue, decimal secondValue)
        {
            return new Multiplication(firstValue, secondValue).Execute();
        }

        public decimal Substract(decimal firstValue, decimal secondValue)
        {
            return new Subtraction(firstValue, secondValue).Execute();
        }
    }
}
