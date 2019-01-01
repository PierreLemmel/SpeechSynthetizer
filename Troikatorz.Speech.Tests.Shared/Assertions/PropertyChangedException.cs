using System;

namespace Troikatorz.Speech.Tests.Assertions
{
    public class PropertyChangedException : Exception
    {
        public PropertyChangedException(string message) : base(message) { }
    }
}
