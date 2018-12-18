using Troikatorz.Speech.Core;
using Troikatorz.Speech.Settings;

namespace Troikatorz.Speech.CommandLine
{
    internal class SettingsMapper : IMapper<Options, SpeechSettings>
    {
        public SpeechSettings Map(Options source)
            => new SpeechSettings(source.Volume, source.Rate, source.Output, source.InputText, source.InputFile, source.OutputFile);
    }
}
