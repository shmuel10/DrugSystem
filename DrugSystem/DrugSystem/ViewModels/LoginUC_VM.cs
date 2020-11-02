using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BLL.BE;
using DrugSystem.Command;
using DrugSystem.Models;

namespace DrugSystem.ViewModels
{
    public class LoginUC_VM : INotifyPropertyChanged
    {
        LoginUC_M _loginUC_M;

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SignInCommand { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public LoginUC_VM()
        {
            _loginUC_M = new LoginUC_M();
            SignInCommand = new SignInCommand(this);         
        }

        public void Login()
        {
            //User currentUser = _loginUC_M.SignIn(Mail, Password);
            // User user = new Doctor();   
            //((App)System.Windows.Application.Current).CurrentElements.CurrentViewModel = new ShellUC_VM();
            //((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell = new DoctorUC_VM();
            //((App)System.Windows.Application.Current).CurrentElements.CurrentUser = currentUser;

            try
            {
                //User currentUser = _loginUC_M.SignIn(Mail, Password);
                User currentUser = new Administrator();
                if (currentUser != null)
                {
                    if (currentUser is Doctor)
                    {
                        ((App)Application.Current).CurrentElements.CurrentViewModel = new ShellUC_VM();
                        ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell = new DoctorUC_VM();
                        ((App)System.Windows.Application.Current).CurrentElements.CurrentUser = currentUser;
                    }
                    else if (currentUser is Administrator)
                    {
                        ((App)Application.Current).CurrentElements.CurrentViewModel = new ShellUC_VM();
                        ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell = new AdminUC_VM();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
