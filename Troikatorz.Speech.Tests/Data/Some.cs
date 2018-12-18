using System.Collections.Generic;
using Troikatorz.Speech.Builders;
using Troikatorz.Speech.Settings;

namespace Troikatorz.Speech.Data
{
    internal static class Some
    {
        public static SpeechSettingsBuilder SpeechSettings => new SpeechSettingsBuilder();

        public static SpeechSettingsBuilder ValidSettingsWithTextInputAndSpeakerOutput => new SpeechSettingsBuilder()
                    .WithSpeakerOutput()
                    .WithInputText(Some.InputText);

        public static SpeechSettingsBuilder ValidSettingsWithTextInputAndFileOutput => new SpeechSettingsBuilder()
                    .WithFileOutput()
                    .WithInputText(Some.InputText)
                    .WithOutputFile(Some.OutputFile);

        public static SpeechSettingsBuilder ValidSettingsWithFileInputAndSpeakerOutput => new SpeechSettingsBuilder()
                    .WithSpeakerOutput()
                    .WithInputFile(Some.InputFile);

        public static SpeechSettingsBuilder ValidSettingsWithFileInputAndFileOutput => new SpeechSettingsBuilder()
                    .WithFileOutput()
                    .WithOutputFile(Some.OutputFile)
                    .WithInputFile(Some.InputFile);

        public static IEnumerable<SpeechSettings> ValidSettings
        {
            get
            {
                yield return ValidSettingsWithTextInputAndSpeakerOutput;
                yield return ValidSettingsWithTextInputAndFileOutput;
                yield return ValidSettingsWithFileInputAndSpeakerOutput;
                yield return ValidSettingsWithFileInputAndFileOutput;
            }
        }

        public static IEnumerable<string> InvalidPathes
        {
            get
            {
                yield return "Hello/..M;ù;???";
                yield return "HelloWorld/\\/";
            }
        }

        public static string OutputFile => "Out/speech.wav";
        public static string InputText => "Bonjour, vous allez bien ?";
        public static string InputFile => "input.txt";
    }
}
