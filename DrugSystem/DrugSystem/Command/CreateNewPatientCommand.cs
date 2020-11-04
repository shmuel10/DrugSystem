using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using BLL.BE;
using DrugSystem.ViewModels;

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
            if ((((App)System.Windows.Application.Current).CurrentElements.CurrentUser) is Administrator ||
                ((App)System.Windows.Application.Current).CurrentElements.CurrentUser.CanAddPatient)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public CreateNewPatientCommand(INotifyPropertyChanged currentVM)
        {
            CurrentVM = currentVM;
        }

        public void Execute(object parameter)
        {
            ((AddNewPatientUC_VM)CurrentVM).CreateNewPatient();
            ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell =
                ((App)System.Windows.Application.Current).CurrentElements.StackOnShell.Peek();
            //AddNewUserWindow win = ((App)System.Windows.Application.Current).Windows.OfType<AddNewUserWindow>().FirstOrDefault();
            //if (win != null)
            //{
            //    win.Close();
            //}
        }
    }
}
