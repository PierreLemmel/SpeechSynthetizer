using System;
using System.Windows;
using System.Windows.Controls;
using Troikatorz.Speech.GUI.ViewModel;

namespace Troikatorz.Speech.GUI.UserControls
{
    /// <summary>
    /// Interaction logic for SpeechButton.xaml
    /// </summary>
    public partial class SpeechButton : UserControl
    {
        public SpeechButton()
        {
            InitializeComponent();
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);

            if (sizeInfo.WidthChanged)
            {
                Height = sizeInfo.NewSize.Width;
            }
        }
    }
}
