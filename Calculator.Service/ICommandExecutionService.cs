namespace Calculator.Service
{
    public interface ICommandExecutionService
    {
        decimal Run(string @operator, decimal firstOperand, decimal secondOperand);
    }
}