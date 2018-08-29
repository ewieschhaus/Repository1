using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AR_COP.Common
{
    /// <summary>
    /// Handler for a Command
    /// </summary>
    public class CommandHandler : ICommand
    {
        private Action mAction;
        private bool mCanExecute;

        /// <summary>
        /// CommandHandler constructor
        /// </summary>
        /// <param name="action">The action to be executed</param>
        /// <param name="canExecute">Whether or not the action can be executed</param>
        public CommandHandler(Action action, bool canExecute = true)
        {
            mAction = action;
            mCanExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return mCanExecute && (mAction != null);
        }

        /// <summary>
        /// Event that fires when CanExecute is changed
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Executes the Action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            mAction();
        }
    }
}
