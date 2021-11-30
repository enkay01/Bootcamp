using System;
using System.Runtime.Serialization;

namespace Calculator2
{
    [Serializable]
    internal class InvalidOperatorException : Exception
    {
        public InvalidOperatorException()
        {
        }

        public InvalidOperatorException(string op) : base(string.Format("{0} is not a supported opperation.", op))
        {
        }

        public InvalidOperatorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidOperatorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}