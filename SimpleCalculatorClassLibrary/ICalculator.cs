using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorClassLibrary
{
    public  interface ICalculator
    {
        int Sum(List<int> numbers);
    }
}
