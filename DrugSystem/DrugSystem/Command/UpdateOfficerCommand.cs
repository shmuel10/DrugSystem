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
    public class UpdateOfficerCommand : ICommand
    {
        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        INotifyPropertyChanged CurrentVM { get; set; }
        public UpdateOfficerCommand(INotifyPropertyChanged currentVM)
        {
            CurrentVM = currentVM;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ((OfficerAdminSideUC_VM)CurrentVM).UpdateOfficer();
        }
    }
}
