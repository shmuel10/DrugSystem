using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BLL.BE;
using DrugSystem.Command;
using DrugSystem.Models;

namespace DrugSystem.ViewModels
{
    public class LoginUC_VM : INotifyPropertyChanged
    {
        LoginUC_M LoginUC_M;

        public event PropertyChangedEventHandler PropertyChanged;

        public SignInCommand SignInCommand { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public LoginUC_VM()
        {
            LoginUC_M = new LoginUC_M();
            SignInCommand = new SignInCommand(this);         
        }
        
        public void Login()
        {
            try
            {
                User currentUser = LoginUC_M.Login(Mail, Password);
                if (currentUser != null)
                {
                    ((App)Application.Current).CurrentUser = currentUser;
                    ShellWindow shellWindow = new ShellWindow();
                    shellWindow.Show();
                    if (currentUser is Doctor)
                    {
                        shellWindow.DoctorUc.Visibility = Visibility.Visible;
                    }
                    else if (currentUser is Administrator)
                    {
                        shellWindow.AdminUc.Visibility = Visibility.Visible;
                    }
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
