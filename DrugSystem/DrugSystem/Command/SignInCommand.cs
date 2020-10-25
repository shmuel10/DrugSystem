using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DrugSystem.ViewModels;

namespace DrugSystem.Command
{
    public class SignInCommand : ICommand
    {
        public LoginUC_VM CurrentVM { get; set; }

        public SignInCommand(LoginUC_VM vm)
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
                CurrentVM.Mail = ((IEnumerable)parameter).Cast<object>().Select(x => x.ToString()).ElementAt(0);
                CurrentVM.Password = ((IEnumerable)parameter).Cast<object>().Select(x => x.ToString()).ElementAt(1);
                CurrentVM.Login();
            }            
        }
    }
}
