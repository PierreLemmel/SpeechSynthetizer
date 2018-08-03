namespace Troikatorz.Speech
{
    internal class SpeechSettings
    {
        public int Volume { get; set; }
        public int Rate { get; set; }
        public SpeechOutput Output { get; set; }
        public string InputText { get; set; }
        public string InputFile { get; set; }
        public string OutputFile { get; set; }
    }
}
