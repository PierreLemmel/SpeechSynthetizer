using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace Troikatorz.Speech.GUI.ViewModel
{
    public class AppViewModel
    {
        public AppViewModel()
        {
            Speeches = new ObservableCollection<SpeechViewModel>(new SpeechViewModel[]
            {
                new SpeechViewModel
                {
                    Title = "Foo",
                    Text = "Bar"
                },
                new SpeechViewModel
                {
                    Title = "Hello",
                    Text = "World"
                },
                new SpeechViewModel
                {
                    Title = "I am",
                    Text = "a toad"
                },
            });
        }

        public ObservableCollection<SpeechViewModel> Speeches { get; }

        public ICommand AddSpeech => new Command<SpeechViewModel>(
            speech =>/* Speeches.Add(speech)*/Debug.WriteLine("Hello"),
            speech => !string.IsNullOrEmpty(speech?.Title));
    }
}
