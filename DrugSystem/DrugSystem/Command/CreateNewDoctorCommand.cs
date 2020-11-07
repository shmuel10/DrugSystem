using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BLL.BE;
using DrugSystem.Models;
using DrugSystem.ViewModels;
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
            //ValidationResult[] validations = parameter as ValidationResult[];

            if ((((App)System.Windows.Application.Current).CurrentElements.CurrentUser) is Administrator ||
                ((App)System.Windows.Application.Current).CurrentElements.CurrentUser.CanAddDoctor)
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
            ((AddNewDoctorUC_VM)CurrentVM).CreateNewDoctor();
            ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell =
                ((App)System.Windows.Application.Current).CurrentElements.StackOnShell.Peek();
        }
    }
}
