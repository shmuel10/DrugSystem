using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.BE;

namespace DrugSystem.ViewModels
{
    public class NewVisitUC_VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Patient CurrentPatient { get; set; }
        public NewVisitUC_VM(Patient currentPatient)
        {
            CurrentPatient = currentPatient;
        }

        public NewVisitUC_VM()
        {
        }
    }
}
