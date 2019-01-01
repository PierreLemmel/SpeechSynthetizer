using System;
using Xunit.Sdk;

namespace Troikatorz.XUnit
{
    public class DoesNotThrowException : AssertActualExpectedException
    {
        public DoesNotThrowException(Exception thrown) : this(thrown, typeof(Exception)) { }
        public DoesNotThrowException(Exception thrown, Type scannedType) : base(
            null,
            thrown,
            $"The code threw an unexpected {scannedType.Name} (exception type: {thrown.GetType().Name})",
            $"No {scannedType.Name}",
            thrown.GetType().Name)
        {
            Exception = thrown;
        }

        public Exception Exception { get; }
    }
}
