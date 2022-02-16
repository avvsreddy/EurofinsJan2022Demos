using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorClassLibrary
{
    public class Calculator : ICalculator
    {
        public int Sum(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
                throw new InvalidInputException("Input is empty or null");

            int sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum = sum + numbers[i];
            }
            return sum;
        }
    }
}
