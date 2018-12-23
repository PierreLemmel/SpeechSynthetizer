using System;
using System.ComponentModel;

namespace Troikatorz.Speech.GUI
{
    internal class ViewModel<TModel> : INotifyPropertyChanged
        where TModel : class
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected TModel Model { get; }

        public ViewModel(TModel model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }

        protected void RaisesPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
