using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DrugSystem.ViewModels;
using DrugSystem.Windows;

namespace DrugSystem.Command
{
    public class CreateNewPatientCommand : ICommand
    {
        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public INotifyPropertyChanged CurrentVM { get; set; }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public CreateNewPatientCommand(INotifyPropertyChanged currentVM)
        {
            CurrentVM = currentVM;
        }

        public void Execute(object parameter)
        {
            ((AddNewPatientUC_VM)CurrentVM).CreateNewPatient();
            AddNewUserWindow win = ((App)System.Windows.Application.Current).Windows.OfType<AddNewUserWindow>().FirstOrDefault();
            if (win != null)
            {
                win.Close();
            }
        }
    }
}
