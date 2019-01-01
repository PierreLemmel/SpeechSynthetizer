using AutoFixture.Kernel;
using System;
using System.Reflection;

namespace Troikatorz.Speech.Tests.Assertions
{
    internal static class SpecimenBuilderExtension
    {
        public static object Create(this ISpecimenBuilder builder, Type type) => builder.CreateContext().Resolve(type);
        public static object Create(this ISpecimenBuilder builder, PropertyInfo property) => builder.CreateContext().Resolve(property);

        private static ISpecimenContext CreateContext(this ISpecimenBuilder builder) => new SpecimenContext(builder);
    }
}
