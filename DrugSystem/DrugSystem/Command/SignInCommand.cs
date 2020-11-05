using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DrugSystem.Models;
using DrugSystem.ViewModels;

namespace DrugSystem.Command
{
    public class SignInCommand : ICommand
    {
        public INotifyPropertyChanged CurrentVM { get; set; }

        public SignInCommand(INotifyPropertyChanged vm)
        {
            CurrentVM = vm;
        }

        public event EventHandler CanExecuteChanged 
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; } 
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter != null)
            {
                // ((LoginWindowVM)CurrentVM).Mail = ((IEnumerable)parameter).Cast<object>().Select(x => x.ToString()).ElementAt(0);
                // ((LoginWindowVM)CurrentVM).Password = ((IEnumerable)parameter).Cast<object>().Select(x => x.ToString()).ElementAt(1);
                ((LoginUC_VM)CurrentVM).Login();
            }            
        }
    }
}
