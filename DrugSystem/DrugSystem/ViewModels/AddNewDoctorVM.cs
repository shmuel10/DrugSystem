using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using BLL.BE;
using static BLL.BE.AuxiliaryObjects;

namespace DrugSystem.Models
{
    class AddNewDoctorVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        AddNewDoctorM newDoctorM;
        Doctor NewDoctor;
        public AddNewDoctorVM()
        {
            newDoctorM = new AddNewDoctorM();
            NewDoctor = new Doctor();
        }

        public string Name 
        {
            get 
            {
                return NewDoctor.FirstName;
            }
            set 
            {
                NewDoctor.FirstName = value;
                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
                }
            }
        }
    }
}
