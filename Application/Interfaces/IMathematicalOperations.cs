namespace Application.Interfaces
{
    public interface IMathematicalOperations
    {
        decimal Add(decimal firstValue, decimal secondValue);
        decimal Substract(decimal firstValue, decimal secondValue);
        decimal Divide(decimal firstValue, decimal secondValue);
        decimal Multiply(decimal firstValue, decimal secondValue);
    }
}
