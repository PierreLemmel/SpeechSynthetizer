using FluentValidation;
using System;
using System.IO;
using System.Speech.Synthesis;
using Troikatorz.Speech.Settings;
using Troikatorz.Speech.Validation;

namespace Troikatorz.Speech.Synthezis
{
    public class Synthesizer
    {
        private readonly IValidator<SpeechSettings> validator;
        private readonly SpeechSynthesizer systemSynthesizer;

        public Synthesizer(IValidator<SpeechSettings> validator, SpeechSynthesizer systemSynthesizer)
        {
            this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
            this.systemSynthesizer = systemSynthesizer ?? throw new ArgumentNullException(nameof(systemSynthesizer));
        }

        public void Synthetize(SpeechSettings settings)
        {
            validator.ThrowIfNotValid(settings);
            
            systemSynthesizer.Volume = settings.Volume;
            systemSynthesizer.Rate = settings.Rate;

            string text = GetText(settings);

            if (settings.Output == SpeechOutput.Speaker)
            {
                systemSynthesizer.Speak(text);
            }
            else if (settings.Output == SpeechOutput.File)
            {
                systemSynthesizer.SetOutputToWaveFile(settings.OutputFile);
                systemSynthesizer.Speak(text);
                systemSynthesizer.SetOutputToDefaultAudioDevice();
            }
        }

        private string GetText(SpeechSettings settings)
        {
            if (!string.IsNullOrWhiteSpace(settings.InputText))
                return settings.InputText;
            else
            {
                string text = File.ReadAllText(settings.InputFile);
                return text;
            }
        }
    }
}
