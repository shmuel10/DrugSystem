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
        LoginUC_M LoginUC_M;

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SignInCommand { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public LoginUC_VM()
        {
            LoginUC_M = new LoginUC_M();
            SignInCommand = new SignInCommand(this);         
        }

        public void Login()
        {
            ((App)System.Windows.Application.Current).CurrentViewModel = new ShellWindowVM();
            ((App)System.Windows.Application.Current).CurrentOnShell = new DoctorUC_VM();

            //    try
            //    {
            //        User currentUser = LoginUC_M.Login(Mail, Password);
            //        if (currentUser != null)
            //        {
            //            if (currentUser is Doctor)
            //            {
            //                ((App)Application.Current).CurrentViewModel = new DoctorUC_VM();
            //            }
            //            else if (currentUser is Administrator)
            //            {
            //                ((App)Application.Current).CurrentViewModel = new AdminUC_VM();
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
        }
    }
}
