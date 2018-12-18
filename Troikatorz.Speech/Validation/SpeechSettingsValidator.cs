using FluentValidation;
using Troikatorz.Speech.Helpers;
using Troikatorz.Speech.Settings;

namespace Troikatorz.Speech.Validation
{
    public class SpeechSettingsValidator : AbstractValidator<SpeechSettings>
    {
        public SpeechSettingsValidator()
        {
            RuleFor(settings => settings.Volume)
                .InclusiveBetween(0, 100);

            RuleFor(settings => settings.Rate)
                .InclusiveBetween(-10, 10);

            RuleFor(settings => settings.Output)
                .IsInEnum();

            RuleFor(settings => settings.OutputFile)
                .NotNull()
                .NotEmpty()
                .IsValidRelativePath()
                .When(settings => settings.Output == SpeechOutput.File);

            RuleFor(settings => settings.InputFile)
                .NotNull()
                .NotEmpty()
                .Unless(settings => !string.IsNullOrEmpty(settings.InputText));

            RuleFor(settings => settings.InputText)
                .NotNull()
                .NotEmpty()
                .Unless(settings => !string.IsNullOrEmpty(settings.InputFile) && Files.IsValidRelativePath(settings.InputFile));
        }
    }
}
