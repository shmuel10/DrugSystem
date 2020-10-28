using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DrugSystem.Command
{
    public class StackCommand : ICommand
    {
        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (((App)System.Windows.Application.Current).StackOnShell.Count > 0)
            {
                ((App)System.Windows.Application.Current).LastFromStack =
                    ((App)System.Windows.Application.Current).StackOnShell.Peek();
                ((App)System.Windows.Application.Current).CurrentOnShell =
                ((App)System.Windows.Application.Current).StackOnShell.Pop();
            }
        }
    }
}
