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
    public class PatientUC_VM : INotifyPropertyChanged
    {
        PatientUC_M PatientUC_M { get; set; }
        public PatientUC_VM(Patient currentPatient)
        {
            CurrentPatient = currentPatient;
            PatientUC_M = new PatientUC_M();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Patient CurrentPatient { get; set; }
    }
}
