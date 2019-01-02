using System.Windows;
using Troikatorz.Speech.GUI.ViewModel;

namespace Troikatorz.Speech.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new AppViewModel();
        }
    }
}
