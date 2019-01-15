using System;
using System.Windows;
using System.Windows.Controls;
using Troikatorz.Speech.GUI.ViewModel;

namespace Troikatorz.Speech.GUI.Selectors
{
    public class SpeechListViewSelector : DataTemplateSelector
    {
        public DataTemplate SpeechDataTemplate { get; set; }
        public DataTemplate AppDataTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            switch (item)
            {
                case SpeechViewModel _:
                    return SpeechDataTemplate;
                case null:
                    return AppDataTemplate;
                default:
                    throw new InvalidOperationException($"Unexpected item type: {item.GetType().Name}");
            }
        }
    }
}