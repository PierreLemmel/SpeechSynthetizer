using Troikatorz.Speech.Data.Model;

namespace Troikatorz.Speech.GUI.ViewModel
{
    public class SpeechViewModel : ViewModelBase<SpeechModel>
    {
        public string Title
        {
            get { return Model.Title; }
            set
            {
                if (value != Title)
                {
                    Model.Title = value;
                    RaisesPropertyChanged(nameof(Title));
                }
            }
        }

        public string Text
        {
            get { return Model.Text; }
            set
            {
                if (value != Text)
                {
                    Model.Text = value;
                    RaisesPropertyChanged(nameof(Text));
                }
            }
        }

    }
}
