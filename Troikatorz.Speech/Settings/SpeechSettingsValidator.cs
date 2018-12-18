using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Troikatorz.Speech.Settings
{
    internal class SpeechSettingsValidator : AbstractValidator<SpeechSettings>
    {
        private const string PathPattern = @"^(.+)/([^/]+)$";

        public SpeechSettingsValidator()
        {
            RuleFor(settings => settings.Volume)
                .InclusiveBetween(0, 100);

            RuleFor(settings => settings.Rate)
                .InclusiveBetween(0, 100);

            RuleFor(settings => settings.Output)
                .IsInEnum();

            RuleFor(settings => settings.OutputFile)
                .NotNull()
                .NotEmpty()
                .Matches(PathPattern)
                .When(settings => settings.Output == SpeechOutput.File);
            
        }
    }
}
