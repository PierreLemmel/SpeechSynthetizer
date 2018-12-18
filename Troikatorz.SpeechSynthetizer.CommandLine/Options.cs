using CommandLine;
using Troikatorz.Speech.Settings;

namespace Troikatorz.Speech.CommandLine
{
    internal class Options
    {
        [Option('v', "volume", Default = 100)]
        public int Volume { get; set; }

        [Option('r', "rate", Default = 0)]
        public int Rate { get; set; }

        [Option('o', "output", Default = SpeechOutput.Speaker)]
        public SpeechOutput Output { get; set; }

        [Option('t', "input-text")]
        public string InputText { get; set; }

        [Option('i', "input-file")]
        public string InputFile { get; set; }

        [Option('f', "output-file", Default = "Speech.wav")]
        public string OutputFile { get; set; }
    }
}
