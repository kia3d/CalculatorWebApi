
using System;

namespace Calculator.Service
{
    public class CalculatorService : ICalculatorService
    {
        public decimal Add(decimal a, decimal b)
        {
            return a + b;
        }

        public decimal Subtract(decimal a, decimal b)
        {
            return a - b;
        }

        public decimal Multiply(decimal a, decimal b)
        {
            return a * b;
        }

        public decimal Divide(decimal a, decimal b)
        {
            if (b == 0)
            {
                throw new OverflowException("Divisor cannot be zero");
            }

            return a / b;
        }
    }
}
