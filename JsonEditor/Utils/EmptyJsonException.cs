using System;

namespace JsonEditor
{
    public class EmptyJsonException : Exception
    {
        public EmptyJsonException()
        { }

        public EmptyJsonException(string message)
            : base(message)
        { }
    }
}
