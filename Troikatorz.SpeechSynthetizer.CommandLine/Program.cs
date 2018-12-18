using CommandLine;
using FluentValidation;
using System;
using System.IO;
using System.Speech.Synthesis;
using Troikatorz.Speech.Core;
using Troikatorz.Speech.Settings;
using Troikatorz.Speech.Synthezis;
using Troikatorz.Speech.Validation;

namespace Troikatorz.Speech.CommandLine
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Parser.Default
                    .ParseArguments<Options>(args)
                    .WithParsed(settings => RunProgram(settings));
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
                Console.ResetColor();
            }
        }

        private static void RunProgram(Options options)
        {
            IMapper<Options, SpeechSettings> settingsMapper = new SettingsMapper();
            SpeechSettings settings = settingsMapper.Map(options);


            Synthesizer synthesizer = BootstrapSynthesizer();
        }

        private static Synthesizer BootstrapSynthesizer()
        {
            IValidator<SpeechSettings> validator = new SpeechSettingsValidator();
            SpeechSynthesizer systemSynthesizer = new SpeechSynthesizer();

            Synthesizer result = new Synthesizer(validator, systemSynthesizer);

            return result;
        }
    }
}