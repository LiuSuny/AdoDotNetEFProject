
using System.Windows.Input;

namespace AdoDotNetEFProject.WPF
{
    public class LambdaCommand : ICommand
    {

        #region Private memeber for reading of variable
        /// <summary>
        /// //Note:Action is delegate that doesn't return anything just like VOID
        /// </summary>
        private readonly Action<object?> _execute;
        /// <summary>
        /// return false or true
        /// </summary>
        private readonly Predicate<object?> _canExecute;

        public LambdaCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute ?? (o => true); //these means each time we forget to initialize our canExcute in an action it will result to true
        }
        #endregion


        public bool CanExecute(object? parameter)
        {
            return _canExecute.Invoke(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute.Invoke(parameter);
        }

        public event EventHandler? CanExecuteChanged
        {
            add    { CommandManager.RequerySuggested += value; } //signup to events
            remove { CommandManager.RequerySuggested -= value; } //signout of event
        }

    }
}
