using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using DrugSystem.Windows;

namespace DrugSystem.Views
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
            return true;
        }

        public void Execute(object parameter)
        {
            ((AddNewOfficerUC_VM)CurrentVM).CreateNewOfficer();
            AddNewUserWindow win = ((App)System.Windows.Application.Current).Windows.OfType<AddNewUserWindow>().FirstOrDefault();
            if (win != null)
            {
                win.Close();
            }
        }
    }
}