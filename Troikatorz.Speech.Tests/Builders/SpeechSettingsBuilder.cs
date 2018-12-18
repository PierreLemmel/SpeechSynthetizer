using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Troikatorz.Speech.Settings;

namespace Troikatorz.Speech.Builders
{
    public class SpeechSettingsBuilder : Builder<SpeechSettings>
    {
        private int volume;
        private int rate;
        private SpeechOutput output;
        private string inputText;
        private string inputFile;
        private string outputFile;

        public SpeechSettingsBuilder()
        {
            InitializeDefaults();
        }

        private void InitializeDefaults()
        {
            volume = 100;
            rate = 0;
            output = SpeechOutput.Speaker;
            inputText = null;
            inputFile = null;
            outputFile = null;
        }

        public SpeechSettingsBuilder WithVolume(int volume)
        {
            this.volume = volume;
            return this;
        }

        public SpeechSettingsBuilder WithRate(int rate)
        {
            this.rate = rate;
            return this;
        }

        public SpeechSettingsBuilder WithOutput(SpeechOutput output)
        {
            this.output = output;
            return this;
        }

        public SpeechSettingsBuilder WithInputText(string inputText)
        {
            this.inputText = inputText;
            return this;
        }

        public SpeechSettingsBuilder WithInputFile(string inputFile)
        {
            this.inputFile = inputFile;
            return this;
        }

        public SpeechSettingsBuilder WithOutputFile(string outputFile)
        {
            this.outputFile = outputFile;
            return this;
        }

        public override SpeechSettings Build() => new SpeechSettings(volume, rate, output, inputText, inputFile, outputFile);
    }
}
