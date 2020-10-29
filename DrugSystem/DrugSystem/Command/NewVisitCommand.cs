using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BLL.BE;
using DrugSystem.ViewModels;

namespace DrugSystem.Command
{
    public class NewVisitCommand : ICommand
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
            PatientUC_VM current = ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell as PatientUC_VM;          
            ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell = new NewVisitUC_VM();
        }
    }
}
