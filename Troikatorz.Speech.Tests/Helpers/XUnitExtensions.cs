using System;
using System.Collections.Generic;
using System.Linq;

namespace Troikatorz.Speech
{
    public static class XUnitExtensions
    {
        public static IEnumerable<object[]> ToMemberDataSource<T>(this IEnumerable<T> sequence) 
            => sequence.Select(elt => new object[] { elt });
    }
}
