using CommandLine;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using Troikatorz.Speech.Settings;

namespace Troikatorz.Speech
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

        private static void RunProgram(Options settings)
        {
            SpeechSynthesizer synthetizer = new SpeechSynthesizer()
            {
                Volume = settings.Volume,
                Rate = settings.Rate,
            };

            string text = GetText(settings);

            if (settings.Output == SpeechOutput.Speaker)
            {
                synthetizer.Speak(text);
            }
            else if (settings.Output == SpeechOutput.File)
            {
                synthetizer.SetOutputToWaveFile(settings.OutputFile);
                synthetizer.Speak(text);
                synthetizer.SetOutputToDefaultAudioDevice();
            }
            else
                throw new Exception($"Unexpected output type: {settings.Output}");
        }

        private static string GetText(Options settings)
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