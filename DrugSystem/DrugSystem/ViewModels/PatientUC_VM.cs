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
        PatientUC_M PatientUC_M { get; set; }
        public List<Visit> Visits { get { return PatientUC_M.Visits; } }
        public List<string> MedicinesNames { get { return PatientUC_M.MedicinesNames; } }
        public PatientUC_VM(Patient currentPatient)
        {
            CurrentPatient = currentPatient;
            PatientUC_M = new PatientUC_M(currentPatient.ID);
        }

        public PatientUC_VM()
        {

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
