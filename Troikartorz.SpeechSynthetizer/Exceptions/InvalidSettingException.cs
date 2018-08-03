using System;

namespace Troikatorz.Speech
{
    internal class InvalidSettingException : Exception
    {
        public InvalidSettingException() : base() { }
        public InvalidSettingException(string message) : base(message) { }
        public InvalidSettingException(string message, Exception innerException) : base(message, innerException) { }
    }
}
