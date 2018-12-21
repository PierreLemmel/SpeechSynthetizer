using System;
using System.Windows.Input;

namespace Troikatorz.Speech.GUI
{
    internal class Command<T> : ICommand
    {
        private readonly Action<object> executeDelegate;
        private readonly Predicate<object> whenDelegate;

        public Command(Action<T> execute, Predicate<T> when)
        {
            if (execute != null)
                this.executeDelegate = obj => execute((T)obj);

            if (when != null)
                this.whenDelegate = obj => when((T)obj);
        }

        private readonly EventHandler canExecuteChangedHandler;
        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        void ICommand.Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
