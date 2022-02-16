using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using SimpleCalculatorClassLibrary;

namespace SimpleCalculatorClassLibrary.UnitTestProject
{
    [TestClass]
    public class CalculatorUnitTest
    {
        [TestMethod]
        public void Sum_WithValidInput_ShouldGiveValidResult()
        {
            // AAA
            // A - Arrange
            List<int> input = new List<int> { 10, 20, 30 };
            int expected = 60;
            Calculator target = new Calculator();
            // A - Act
            int actual = target.Sum(input);
            // A - Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void Sum_WithEmptyInput_ShouldThrowExp()
        {
            Calculator target = new Calculator();
            target.Sum(null);
        }
    }
}
