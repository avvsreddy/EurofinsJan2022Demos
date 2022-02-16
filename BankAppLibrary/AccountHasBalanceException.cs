using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppLibrary
{
    public class AccountHasBalanceException : ApplicationException
    {
        public AccountHasBalanceException(string msg = null, Exception exception = null):base(msg,exception)
        {

        }
    }
}
