using System;
using System.Windows.Input;

namespace Marathon.Core.ViewModel.Base
{
    /// <summary>
    /// A basic command that runs an Action
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Private Members

        /// <summary>
        /// Action to execute
        /// </summary>
        private readonly Action<object> _execute;

        /// <summary>
        /// Contrainsts execute action
        /// </summary>
        private readonly Predicate<object> _canExecute;

        #endregion

        #region Public Events

        /// <summary>
        /// The event thats fired when the <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Constructor

        /// <summary>
        /// Execute action without constraint
        /// </summary>
        /// <param name="execute">Action to execute</param>
        public RelayCommand(Action<object> execute) : this(execute, null)
        {

        }

        /// <summary>
        /// Execute action with constraint
        /// </summary>
        /// <param name="execute">Action to execute</param>
        /// <param name="canExecute">Constraints to execute action</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentException(nameof(execute));
            _canExecute = canExecute;
        }

        #endregion

        #region Command Methods

        public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        public void Execute(object parameter) => _execute?.Invoke(parameter);
        
        #endregion
    }
}
