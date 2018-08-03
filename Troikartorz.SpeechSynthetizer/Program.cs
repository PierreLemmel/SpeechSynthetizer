using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading.Tasks;

namespace Troikatorz.Speech
{
    public static class Program
    {
        /// <summary>
        /// t: input text - The raw text that has to be readen.
        /// i: the input file - The input file that will be readen.
        /// r: rate - Integer from -10 to 10
        /// v: Volume - Integet from 0 to 100
        /// o: Output - possible values: "file|speaker"
        /// f: File - output file: must be a valid path
        /// </summary>
        private static IReadOnlyDictionary<string, string> DefaultValues { get; } = new Dictionary<string, string>(Comparer)
        {
            { "t", null },
            { "i", null },
            { "r", "0" },
            { "v", "100" },
            { "o", "speaker" },
            { "f", "speech.wav" },
        };

        private static IDictionary<string, string> CommandLineArguments { get; } = new Dictionary<string, string>(Comparer);

        private static SpeechSettings Settings { get; } = new SpeechSettings();

        private static IEqualityComparer<string> Comparer { get; } = StringComparer.InvariantCultureIgnoreCase;

        private static NumberStyles NumberStyle { get; } = NumberStyles.Any;

        private static IFormatProvider Format { get; } = CultureInfo.InvariantCulture;

        public static void Main(string[] args)
        {
            try
            {
                InitializeCommandLineArguments(args);
                InitializeSpeechSettings();

                string text = GetText();
                SynthetizeText(text);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.Read();
        }

        private static void InitializeCommandLineArguments(string[] args)
        {
            if (!args.Any()) throw new CommandLineArgumentException("No text provided");

            string text = args[0];

            int argc = args.Length;
            for (int i = 0; i < argc; i += 2)
            {
                string key = args[i];

                if (key.StartsWith("-"))
                    key = key.TrimStart(new char[] { '-' });
                else
                    throw new CommandLineArgumentException($"Invalid key: {key}");

                if (i + 1 >= argc)
                    throw new CommandLineArgumentException($"No value for the following key: {key}");

                string value = args[i + 1];

                CommandLineArguments.Add(key, value);
            }

            IEnumerable<string> excessKeys = CommandLineArguments.Keys.Except(DefaultValues.Keys, Comparer);
            if (excessKeys.Any())
                throw new CommandLineArgumentException("Unknown keys: " + string.Join(", ", excessKeys));
        }

        private static void InitializeSpeechSettings()
        {
            #region Speed
            string ratesTr = GetValueForKey("r");

            if (int.TryParse(ratesTr, NumberStyle, Format, out int rate))
            {
                if (rate >= -10 && rate < 10)
                    Settings.Rate = rate;
                else
                    throw new InvalidSettingException("The rate must be between -10 and 10");
            }
            else
                throw new InvalidSettingException("The rate value must be an integer");
            #endregion

            #region Volume
            string volumeStr = GetValueForKey("v");

            if (int.TryParse(volumeStr, NumberStyle, Format, out int volume))
            {
                if (volume >= 0 && volume <= 100)
                    Settings.Volume = volume;
                else
                    throw new InvalidSettingException("The volume must be between 0.0 and 100.0");
            }
            else
                throw new InvalidSettingException("The volume value must be an integer");
            #endregion

            #region Ouput
            string outputStr = GetValueForKey("o");

            if (Enum.TryParse(outputStr, true, out SpeechOutput output))
            {
                if (output == SpeechOutput.File || output == SpeechOutput.Speaker)
                    Settings.Output = output;
                else
                    throw new InvalidSettingException("The output must be one of the following values : speaker|file");
            }
            else
                throw new InvalidSettingException("The output must be one of the following values : speaker|file");
            #endregion

            #region Output file
            string outputFile = GetValueForKey("f");

            try
            {
                FileInfo fi = new FileInfo(outputFile);
            }
            catch (Exception ex)
            {
                throw new InvalidSettingException($"The following path is not valid: {outputFile}", ex);
            }

            Settings.OutputFile = outputFile;
            #endregion

            #region Input Text
            string inputText = GetValueForKey("t");
            Settings.InputText = inputText;
            #endregion

            #region Input File
            string inputFile = GetValueForKey("i");

            try
            {
                FileInfo fi = new FileInfo(inputFile);
            }
            catch (Exception ex)
            {
                throw new InvalidSettingException($"The following path is not valid: {inputFile}", ex);
            }

            Settings.InputFile = inputFile;
            #endregion
        }

        private static string GetText()
        {
            if (!string.IsNullOrWhiteSpace(Settings.InputText))
                return Settings.InputText;
            else if (!string.IsNullOrWhiteSpace(Settings.InputFile))
            {
                string text = File.ReadAllText(Settings.InputFile);
                return text;
            }
            else
                throw new CommandLineArgumentException("At least one the following arguments must be provided: input text or input file");
        }

        private static void SynthetizeText(string text)
        {
            SpeechSynthesizer synthetizer = new SpeechSynthesizer()
            {
                Volume = Settings.Volume,
                Rate = Settings.Rate,
            };

            if (Settings.Output == SpeechOutput.Speaker)
            {
                synthetizer.Speak(text);
            }
            else if (Settings.Output == SpeechOutput.File)
            {
                synthetizer.SetOutputToWaveFile(Settings.OutputFile);
                synthetizer.Speak(text);
                synthetizer.SetOutputToDefaultAudioDevice();
            }
            else
                throw new Exception($"Unexpected output type: {Settings.Output}");
        }

        private static string GetValueForKey(string key)
        {
            if (CommandLineArguments.TryGetValue(key, out string value))
                return value;
            else if (DefaultValues.TryGetValue(key, out value))
                return value;
            else
                throw new MissingValueException($"No value found for the following key: {key}");
        }
    }
}
