using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Troikatorz.Speech.Builders;
using Troikatorz.Speech.Settings;

namespace Troikatorz.Speech.Data
{
    internal static class Some
    {
        public static IEnumerable<SpeechSettings> ValidSettings
        {
            get
            {
                yield return new SpeechSettingsBuilder()
                    .WithOutput(SpeechOutput.Speaker)
                    .WithInputText(Some.InputText);

                yield return new SpeechSettingsBuilder()
                    .WithOutput(SpeechOutput.Speaker)
                    .WithInputFile(Some.InputFile);

                yield return new SpeechSettingsBuilder()
                    .WithOutput(SpeechOutput.Speaker)
                    .WithOutputFile(Some.OutputFile)
                    .WithInputText(Some.InputText);

                yield return new SpeechSettingsBuilder()
                    .WithOutput(SpeechOutput.Speaker)
                    .WithOutputFile(Some.OutputFile)
                    .WithInputFile(Some.InputFile);
            }
        }

        public static string OutputFile => "speech.wav";
        public static string InputText => "Bonjour, vous allez bien ?";
        public static string InputFile => "input.txt";
    }
}
