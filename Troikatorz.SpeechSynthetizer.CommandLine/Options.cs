using CommandLine;
using Troikatorz.Speech.Settings;
using Troikatorz.SpeechSynthetizerS;

namespace Troikatorz.Speech.CommandLine
{
    internal class Options
    {
        [Option('v', "volume", Default = 100)]
        public int Volume { get; set; }

        [Option('r', "rate", Default = 0)]
        public int Rate { get; set; }

        [Option('o', "output", Default = OutputType.speaker)]
        public OutputType Output { get; set; }

        [Option('t', "input-text")]
        public string InputText { get; set; }

        [Option('i', "input-file")]
        public string InputFile { get; set; }

        [Option('f', "output-file", Default = "Speech.wav")]
        public string OutputFile { get; set; }
    }
}
