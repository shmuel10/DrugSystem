using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BLL.BE;
using DrugSystem.Command;
using static BLL.BE.AuxiliaryObjects;

namespace DrugSystem.Models
{
    class AddNewDoctorVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        AddNewDoctorUC_M newDoctorM;
        Doctor NewDoctor;
        public ICommand CreateNewDoctorCommand { get; set; }
        public Window NewDoctorWindow { get; set; }
        public AddNewDoctorVM(Window window)
        {
            NewDoctorWindow = window;
            newDoctorM = new AddNewDoctorUC_M();
            NewDoctor = new Doctor();
         
        }

        public void CreateNewDoctor()
        {
            newDoctorM.AddNewDoctor(NewDoctor);
            NewDoctorWindow.Close();
        }

        public bool E{ get; set; }
        //public string FirstName 
        //{
        //    get 
        //    {
        //        return NewDoctor.FirstName;
        //    }
        //    set 
        //    {
        //        NewDoctor.FirstName = value;
        //        if(PropertyChanged != null)
        //        {
        //            PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
        //        }
        //    }
        //}
    }
}
