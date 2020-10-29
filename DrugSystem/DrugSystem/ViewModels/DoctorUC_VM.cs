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

namespace DrugSystem.ViewModels
{
    public class DoctorUC_VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        DoctorUC_M DoctorUC_M;
        Patient _selectedPatient;
        public List<Patient> Patients { get { return DoctorUC_M.Patients; } }
        public Patient SelectedPatient { get { return _selectedPatient; }
            set {
                _selectedPatient = value;
                if(value.ID != null)
                {
                    ((App)System.Windows.Application.Current).CurrentOnShell = 
                        new PatientUC_VM(_selectedPatient);
                    if(PropertyChanged != null)
                    {
                        ((App)System.Windows.Application.Current).CurrentPatient = _selectedPatient;
                        PropertyChanged(this, new PropertyChangedEventArgs("SelectedPatient"));
                    }
                }
            }
        }

        public DoctorUC_VM()
        {
            DoctorUC_M = new DoctorUC_M();
            _selectedPatient = new Patient();
            SelectedPatient = new Patient();
        }
    }
}
