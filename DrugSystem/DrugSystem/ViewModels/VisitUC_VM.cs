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
    public class VisitUC_VM : INotifyPropertyChanged
    {
        VisitUC_M _visitUC_M;
        public event PropertyChangedEventHandler PropertyChanged;
        public Visit OldVisit { get; set; }
        public Prescription TreatOfOldVisit { get; set; }
        public Patient Patient { get; set; }

        public VisitUC_VM()
        {
            _visitUC_M = new VisitUC_M();
            OldVisit = ((App)System.Windows.Application.Current).CurrentElements.VisitSelected;
            Patient = _visitUC_M.GetPatientByID(OldVisit?.PatientID);
            TreatOfOldVisit = _visitUC_M.GetPrescriptionByNum(OldVisit.VisitID);
        }
    }
}
