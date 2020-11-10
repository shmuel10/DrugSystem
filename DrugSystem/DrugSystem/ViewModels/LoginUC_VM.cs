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
        string _mail;
        public string Mail { get { return _mail; }
            set {
                _mail = value;
                if(value?.Length > 0)
                {
                    ErrorMessage = "";
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Mail"));
                }
            }
        }
        string _password;
        public string Password { get { return _password; }
            set {
                _password = value;
                if (value?.Length > 0)
                {
                    ErrorMessage = "";
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Password"));
                }
            } 
        }

        private string _errorMessage = string.Empty;
        public string ErrorMessage {
            get { return _errorMessage; }
            set {
                _errorMessage = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ErrorMessage"));
            }
        }
        public LoginUC_VM()
        {
            _loginUC_M = new LoginUC_M();
            SignInCommand = new SignInCommand(this);         
        }

        public void Login(string mail, string password)
        {
            try
            {
                User currentUser = _loginUC_M.SignIn(mail, password);
               // User currentUser = _loginUC_M.SignIn(Mail, Password);
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
                        ((App)System.Windows.Application.Current).CurrentElements.CurrentUser = currentUser;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
