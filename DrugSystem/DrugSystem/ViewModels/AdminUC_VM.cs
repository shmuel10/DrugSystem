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
    
    public class AdminUC_VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public AdminUC_M AdminUC_M { get; set; }
      
        public AdminUC_VM()
        {
            AdminUC_M = new AdminUC_M();
           
        }

        public List<Doctor> Doctors { get { return AdminUC_M.Doctors; } }
        public List<Patient> Patients { get { return AdminUC_M.Patients; } }
        public List<Officer> Officers { get { return AdminUC_M.Officers; } }
        public List<Medicine> Medicines { get { return AdminUC_M.Medicines; } }


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
