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
            if (execute is null) throw new ArgumentNullException(nameof(execute));

            executeDelegate = obj => execute((T)obj);

            if (when != null)
                whenDelegate = obj => whenDelegate((T)obj);
            else
                whenDelegate = obj => true;
        }

        private EventHandler canExecuteChangedHandler;
        event EventHandler ICommand.CanExecuteChanged
        {
            add => canExecuteChangedHandler += value;
            remove => canExecuteChangedHandler -= value;
        }

        bool ICommand.CanExecute(object parameter) => whenDelegate(parameter);

        void ICommand.Execute(object parameter) => executeDelegate(parameter);
    }
}
