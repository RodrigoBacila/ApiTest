using Application.Interfaces;
using Domain.MathematicalOperations;

namespace Application.Services
{
    public class MathematicalOperations : IMathematicalOperations
    {
        
        public int Add(int firstValue, int secondValue)
        {
            return new Addition(firstValue, secondValue).Execute();
        }

        public int Divide(int firstValue, int secondValue)
        {
            return new Division(firstValue, secondValue).Execute();
        }

        public int Multiply(int firstValue, int secondValue)
        {
            return new Multiplication(firstValue, secondValue).Execute();
        }

        public int Substract(int firstValue, int secondValue)
        {
            return new Substraction(firstValue, secondValue).Execute();
        }
    }
}
