using System;
using System.Runtime.Serialization;

namespace BankAppLibrary
{
    [Serializable]
    public class IncorrectPinException : ApplicationException
    {
        public IncorrectPinException()
        {
        }

        public IncorrectPinException(string message) : base(message)
        {
        }

        public IncorrectPinException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IncorrectPinException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}