using System;
using System.ComponentModel;

namespace Troikatorz.Speech.GUI
{
    public class ViewModelBase<TModel> : INotifyPropertyChanged
        where TModel : class
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected TModel Model { get; }

        public ViewModelBase(TModel model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }

        protected void RaisesPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
