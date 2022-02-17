using System;
using System.Runtime.Serialization;

namespace BankAppLibrary
{
    [Serializable]
    public class InactiveAccountException : ApplicationException
    {
        public InactiveAccountException()
        {
        }

        public InactiveAccountException(string message) : base(message)
        {
        }

        public InactiveAccountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InactiveAccountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}