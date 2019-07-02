using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NLPKit.Internals
{
    public class ReadException : Exception
    {
        public ReadException()
        {
        }

        public ReadException(string message) : base(message)
        {
        }

        public ReadException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ReadException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
