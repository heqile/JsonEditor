using System;

namespace JsonEditor
{
    public class InvalidJsonException : Exception
    {
        public InvalidJsonException()
        { }

        public InvalidJsonException(string message)
            : base(message)
        { }
    }
}
