using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using BLL.BE;
using DrugSystem.ViewModels;

namespace DrugSystem.Command
{
    public class CreateNewOfficerCommand : ICommand
    {
        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public INotifyPropertyChanged CurrentVM { get; set; }

        public CreateNewOfficerCommand(INotifyPropertyChanged currentVM)
        {
            this.CurrentVM = currentVM;
        }
        public bool CanExecute(object parameter)
        {
            if (((App)System.Windows.Application.Current).CurrentElements.CurrentUser is Administrator)
            {
                return true;
            }
            else
            {
                return false;
            }
                
        }

        public void Execute(object parameter)
        {
            ((AddNewOfficerUC_VM)CurrentVM).Save();

        }
    }
}