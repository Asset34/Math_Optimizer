using System;
using System.Windows.Input;

namespace MathOptimizer.MVVM
{
    class RelayCommand : ICommand
    {
        public Predicate<object> CanExecuteDelegate { get; }
        public Action<object> ExecuteDelegate { get; }

        public event EventHandler CanExecuteChanged = delegate { };

        public RelayCommand(Action<object> action, Predicate<object> predicate)
        {
            ExecuteDelegate = action;
            CanExecuteDelegate = predicate;
        }
        public bool CanExecute(object parameter)
        {
            if (CanExecuteDelegate != null)
            {
                return CanExecuteDelegate(parameter);
            }

            return true;
        }
        public void Execute(object parameter)
        {
            if (ExecuteDelegate != null)
            {
                ExecuteDelegate(parameter);
            }
        }
    }
}
