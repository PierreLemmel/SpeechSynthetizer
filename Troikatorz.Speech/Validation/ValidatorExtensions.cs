using FluentValidation;
using FluentValidation.Results;

namespace Troikatorz.Speech.Validation
{
    public static class ValidatorExtensions
    {
        public static void ThrowIfNotValid<T>(this IValidator<T> validator, T instance)
        {
            ValidationResult result = validator.Validate(instance);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);
        }
    }
}
