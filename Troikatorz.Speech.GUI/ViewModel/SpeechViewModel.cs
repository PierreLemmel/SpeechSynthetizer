using Troikatorz.Speech.Data.Model;

namespace Troikatorz.Speech.GUI.ViewModel
{
    internal class SpeechViewModel : ViewModelBase<SpeechModel>
    {
        public SpeechViewModel(SpeechModel model) : base(model)
        {
        }

        public string Title { get; set; }
        public string Text { get; set; }
    }
}
