using System;
using Troikatorz.Speech.GUI.Builders;

namespace Troikatorz.Speech.GUI.Data
{
    internal static class Some
    {
        public static Predicate<T> AlwaysMatchedPredicate<T>() => (t => true);

        public static Action<T> Action<T>() => t => { };
        public static Predicate<T> Predicate<T>() => t => (t?.GetHashCode() ?? 42) % 2 == 0;

        public static ExampleViewModelBuilder ExampleViewModel => new ExampleViewModelBuilder();
    }
}
