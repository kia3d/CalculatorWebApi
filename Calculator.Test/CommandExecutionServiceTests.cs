using Calculator.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Calculator.Test
{
    [TestClass]
    public class CommandExecutionServiceTests
    {
        private readonly Mock<ICalculatorService> _mockCalculatorService;
        private readonly CommandExecutionService _commandExecutionService;
        private const decimal firstOperand = 1;
        private const decimal secondOperand = 2;

        public CommandExecutionServiceTests()
        {
            _mockCalculatorService = new Mock<ICalculatorService>();
            _commandExecutionService = new CommandExecutionService(_mockCalculatorService.Object);
        }

        [TestMethod]
        public void GivenExecutingCommandWhenPassingInvalidOperationThenSystemThrowArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => _commandExecutionService.Run("test", firstOperand, secondOperand));
        }

        [TestMethod]
        [DataRow("add")]
        [DataRow("addition")]
        [DataRow("Add")]
        [DataRow("Addition")]
        public void GivenExecutingCommandWhenPassingAddOperationThenAdditionMethodCalled(string command)
        {
            _commandExecutionService.Run(command, firstOperand, secondOperand);
            _mockCalculatorService.Verify(x => x.Add(firstOperand, secondOperand), Times.Once);
        }

        [TestMethod]
        [DataRow("sub")]
        [DataRow("subtraction")]
        [DataRow("Sub")]
        [DataRow("Subtraction")]
        public void GivenExecutingCommandWhenPassingSubOperationThenSubtractionMethodCalled(string command)
        {
            _commandExecutionService.Run(command, firstOperand, secondOperand);
            _mockCalculatorService.Verify(x => x.Subtract(firstOperand, secondOperand), Times.Once);
        }

        [TestMethod]
        [DataRow("mul")]
        [DataRow("multiplication")]
        [DataRow("Mul")]
        [DataRow("Multiplication")]
        public void GivenExecutingCommandWhenPassingMulOperationThenMultiplicationMethodCalled(string command)
        {
            _commandExecutionService.Run(command, firstOperand, secondOperand);
            _mockCalculatorService.Verify(x => x.Multiply(firstOperand, secondOperand), Times.Once);
        }

        [TestMethod]
        [DataRow("div")]
        [DataRow("division")]
        [DataRow("Div")]
        [DataRow("Division")]
        public void GivenExecutingCommandWhenPassingDivOperationThenDivisionnMethodCalled(string command)
        {
            _commandExecutionService.Run(command, firstOperand, secondOperand);
            _mockCalculatorService.Verify(x => x.Divide(firstOperand, secondOperand), Times.Once);
        }
    }

}
