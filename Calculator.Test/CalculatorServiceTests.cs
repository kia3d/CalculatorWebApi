using Calculator.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculator.Test
{
    [TestClass]
    public class CalculatorServiceTests
    {
        private readonly ICalculatorService _calculatorService;
        public CalculatorServiceTests()
        {
            _calculatorService = new CalculatorService();
        }

        [TestMethod]
        public void GivenAddOperationWhenValidParametersPassedThenCorrectResultReturns()
        {
            Assert.AreEqual(_calculatorService.Add(1, 2), 3);
        }

        [TestMethod]
        public void GivenSubOperationWhenValidParametersPassedThenCorrectResultReturns()
        {
            Assert.AreEqual(_calculatorService.Subtract(3, 2), 1);
        }

        [TestMethod]
        public void GivenMulOperationWhenValidParametersPassedThenCorrectResultReturns()
        {
            Assert.AreEqual(_calculatorService.Multiply(10, 2), 20);
        }

        [TestMethod]
        public void GivenDivOperationWhenValidParametersPassedThenCorrectResultReturns()
        {
            Assert.AreEqual(_calculatorService.Divide(10, 2), 5);
        }

        [TestMethod]
        public void GivenDivOperationWhenZeroPassedAsSecondOperandThenSystemThrowOverFlowException()
        {
            Assert.ThrowsException<OverflowException>(() => _calculatorService.Divide(10, 0));
        }
    }
}
