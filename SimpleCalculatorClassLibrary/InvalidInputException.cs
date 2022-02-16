using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorClassLibrary
{
    public class InvalidInputException : ApplicationException
    {
        public InvalidInputException(string msg = null,Exception ex = null) : base(msg,ex)
        {

        }
    }
}
