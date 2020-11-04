using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DrugSystem.ViewModels;

namespace DrugSystem.Command
{
    public class UpdatePatientCommand : ICommand
    {
        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        INotifyPropertyChanged CurrentVM { get; set; }
        public UpdatePatientCommand(INotifyPropertyChanged currentVM)
        {
            CurrentVM = currentVM;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ((PatientAdminSideUC_VM)CurrentVM).UpdatePatient();
            ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell =
                ((App)System.Windows.Application.Current).CurrentElements.StackOnShell.Peek();
        }
    }
}
