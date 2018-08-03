using System;

namespace Troikatorz.Speech
{
    internal class CommandLineArgumentException : Exception
    {
        public CommandLineArgumentException() : base() { }
        public CommandLineArgumentException(string message) : base(message) { }
        public CommandLineArgumentException(string message, Exception innerException) : base(message, innerException) { }
    }
}
