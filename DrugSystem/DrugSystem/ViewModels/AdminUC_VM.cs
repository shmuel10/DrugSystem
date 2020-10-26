using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DrugSystem.Models;

namespace DrugSystem.ViewModels
{
    
    class AdminUC_VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public AdminUC_M AdminUC_M { get; set; }
        public object FloatingButtons { get; private set; }

        public AdminUC_VM()
        {
            AdminUC_M = new AdminUC_M();
        }

        private void Button_PreviewMouseMove(object sender, MouseEventArgs e)
        {
           // this.FloatingButtons.Visibility = Visibility.Visible;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
          //  this.FloatingButtons.Visibility = Visibility.Collapsed;
        }   
    }
}
