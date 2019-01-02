using System;
using System.ComponentModel;

namespace Troikatorz.Speech.GUI
{
    public class ViewModelBase<TModel> : INotifyPropertyChanged
        where TModel : class, new()
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected TModel Model { get; }

        public ViewModelBase()
        {
            Model = new TModel();
        }

        protected void RaisesPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
