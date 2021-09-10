using System; 
using System.Windows.Input;

namespace Metrohm_Unit.Core
{

    public class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private bool _isExecuting = false;
        public bool IsExecuting
        {
            get => _isExecuting;
            set
            {
                _isExecuting = value;
                CanExecuteChanged?.Invoke(this, new EventArgs());


            }
        }

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> execute)
        {
            _execute = execute;
        }
        public bool CanExecute(object parameter) => !IsExecuting;
        public void Execute(object parameter) => _execute(parameter);
    }
}
