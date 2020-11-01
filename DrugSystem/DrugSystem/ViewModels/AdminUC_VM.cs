using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
        AdminUC_M _adminUC_M { get; set; }
        ICommand command { get; set; }
        public ObservableCollection<Doctor> Doctors { get; set; }
        public ObservableCollection<Officer> Officers { get; set; }
        public ObservableCollection<Patient> Patients { get; set; }
        public ObservableCollection<Medicine> Medicines { get; set; }

        public AdminUC_VM()
        {
            _adminUC_M = new AdminUC_M();
            command = new NewItemCommand();
            Doctors = new ObservableCollection<Doctor>(_adminUC_M.Doctors);
            Officers = new ObservableCollection<Officer>(_adminUC_M.Officers);
            Patients = new ObservableCollection<Patient>(_adminUC_M.Patients);
            Medicines = new ObservableCollection<Medicine>(_adminUC_M.Medicines);
        }
    }
}
