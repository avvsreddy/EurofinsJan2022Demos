using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppLibrary
{
    public class AccountAlreadyClosedException : ApplicationException
    {
        public AccountAlreadyClosedException(string msg=null, Exception exception = null):base(msg,exception)
        {

        }
    }
}
