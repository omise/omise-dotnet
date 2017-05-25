using System;

namespace Omise
{
    public class OmiseException : Exception
    {
        public OmiseException()
        {
        }

        public OmiseException(string message) : base(message)
        {
        }

        public OmiseException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}