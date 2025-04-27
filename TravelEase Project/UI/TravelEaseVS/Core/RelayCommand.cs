using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace TravelEaseVS.Core
{
    class RelayCommand : ICommand
    {
        private Action<object> action;
        private Func<object, bool> func;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> exec, Func<object, bool> can_exec = null)
        {
            action = exec;
            func = can_exec;
        }

        public bool CanExecute(object parameter)
        {
            return func == null || func(parameter);
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }

    }
}
