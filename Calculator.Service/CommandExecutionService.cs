using System;

namespace Calculator.Service
{
    public class CommandExecutionService : ICommandExecutionService
    {
        private readonly ICalculatorService _calculatorService;

        public CommandExecutionService(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        public decimal Run(string @operator, decimal firstOperand, decimal secondOperand)
        {
            switch (@operator.ToLowerInvariant())
            {
                case "add":
                case "addition":
                    return _calculatorService.Add(firstOperand, secondOperand);

                case "sub":
                case "subtraction":
                    return _calculatorService.Subtract(firstOperand, secondOperand);

                case "mul":
                case "multiplication":
                    return _calculatorService.Multiply(firstOperand, secondOperand);

                case "div":
                case "division":
                    return _calculatorService.Divide(firstOperand, secondOperand);

                default:
                    throw new ArgumentException($"Invalid operation '{@operator}'. Vaid operations are Add/Addition, Sub/Subtraction, Div/Division, Mul/Multiplication");
            }
        }
    }
}
