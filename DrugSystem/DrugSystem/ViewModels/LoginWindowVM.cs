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
    public class LoginWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        LoginWindowM loginWindowM;

        public ICommand SignInCommand { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
       

        public LoginWindowVM()
        {
            //((App)System.Windows.Application.Current).CurrentWindow = new LoginWindow();
            loginWindowM = new LoginWindowM();
            SignInCommand = new SignInCommand(this);
        }

        public void Login()
        {
            try
            {
                User currentUser = loginWindowM.Login(Mail, Password);
                if (currentUser != null)
                {
                    
                    if (currentUser is Doctor)
                    {
                        ((App)Application.Current).CurrentViewModel = new DoctorUC_VM();
                    }
                    else if (currentUser is Administrator)
                    {
                        ((App)System.Windows.Application.Current).CurrentViewModel = new AdminUC_VM();
                    }
                    ShellWindow shell = new ShellWindow();
                    shell.Show();
                    ((App)System.Windows.Application.Current).CurrentWindow = shell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
