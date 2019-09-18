using System;

namespace ModelToKeyValue.src.Exceptions
{
    [Serializable]
    internal class InvalidRegexException : Exception
    {
        public InvalidRegexException() { }

        public InvalidRegexException(string Message) : base(Message) { }
    }
}
