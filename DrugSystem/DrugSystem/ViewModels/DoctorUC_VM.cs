using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.BE;

namespace DrugSystem.ViewModels
{
    public class DoctorUC_VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Patient _selectedPatient;
        public Patient SelectedPatient { get { return _selectedPatient; }
            set {
                _selectedPatient = value;
                ((App)System.Windows.Application.Current).CurrentViewModel = new PatientUC_VM(_selectedPatient as Patient);
            }
        }

        public DoctorUC_VM()
        {
            _selectedPatient = new Patient();
            SelectedPatient = new Patient();
        }
    }
}
