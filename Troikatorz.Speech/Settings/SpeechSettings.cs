namespace Troikatorz.Speech.Settings
{
    public class SpeechSettings
    {
        public SpeechSettings(int volume, int rate, SpeechOutput output, string inputText, string inputFile, string outputFile)
        {
            Volume = volume;
            Rate = rate;
            Output = output;
            InputText = inputText;
            InputFile = inputFile;
            OutputFile = outputFile;
        }

        public int Volume { get; }
        public int Rate { get; }
        public SpeechOutput Output { get; }
        public string InputText { get; }
        public string InputFile { get; }
        public string OutputFile { get; }
    }
}
