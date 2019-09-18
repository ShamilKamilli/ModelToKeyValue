using System;

namespace ModelToKeyValue.src.Exceptions
{
    [Serializable]
    internal class InvalidOperationException:Exception
    {
        public InvalidOperationException() { }

        public InvalidOperationException(string Message) : base(Message) { }
    }
}
