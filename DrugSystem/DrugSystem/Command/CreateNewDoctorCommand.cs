using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows;
using System.Windows.Input;
using DrugSystem.Models;
using DrugSystem.ViewModels;
using DrugSystem.Windows;
using MahApps.Metro.Controls;

namespace DrugSystem.Command
{
    public class CreateNewDoctorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public INotifyPropertyChanged CurrentVM { get; set; }
       
        public CreateNewDoctorCommand(INotifyPropertyChanged currentVM)
        {
            CurrentVM = currentVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ((AddNewDoctorUC_VM)CurrentVM).CreateNewDoctor();
            AddNewUserWindow win = ((App)System.Windows.Application.Current).
                Windows.OfType<AddNewUserWindow>().FirstOrDefault();
            if(win!= null)
            {
                win.Close();
            }
        }
    }
}
