namespace Calculator.Service
{
    public interface ICalculatorService
    {
        decimal Add(decimal a, decimal b);
        decimal Divide(decimal a, decimal b);
        decimal Multiply(decimal a, decimal b);
        decimal Subtract(decimal a, decimal b);
    }
}