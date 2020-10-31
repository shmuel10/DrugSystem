using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.BE;
using DrugSystem.Models;

namespace DrugSystem.ViewModels
{
    class PatientUC_VM : INotifyPropertyChanged
    {
        PatientUC_M _patientUC_M;
        public List<Visit> Visits { get { return _patientUC_M.Visits; } }
        public List<string> MedicinesNames { get { return _patientUC_M.MedicinesNames; } }
        public PatientUC_VM()
        {
            CurrentPatient = ((App)System.Windows.Application.Current).CurrentElements.CurrentPatient;
            _patientUC_M = new PatientUC_M(CurrentPatient.ID);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private Patient _currentPatient;
        public Patient CurrentPatient {
            get { return _currentPatient; }
            set {
                _currentPatient = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentPatient"));
            }
        }
    }
}
