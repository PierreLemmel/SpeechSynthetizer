using FluentValidation;
using System;
using Troikatorz.Speech.Helpers;

namespace Troikatorz.Speech.Validation
{
    public static class RuleBuilderOptionsExtensions
    {
        public static IRuleBuilderOptions<T, string> IsValidRelativePath<T>(this IRuleBuilderOptions<T, string> builderOptions)
            => builderOptions.Must(input => Files.IsValidRelativePath(input));
    }
}
