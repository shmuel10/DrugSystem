using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BLL.BE;
using DrugSystem.Command;
using DrugSystem.Models;
using static BLL.BE.AuxiliaryObjects;

namespace DrugSystem.ViewModels
{
    public class PatientAdminSideUC_VM : INotifyPropertyChanged
    {
        PatientAdminSideUC_M _patientAdminSide_M;
        public ICommand UpdatePatientDetailes { get; set; }
        public List<Gender> Gender { get; set; }
        public Patient PatientForUpdate { get; set; }

        public PatientAdminSideUC_VM()
        {
            _patientAdminSide_M = new PatientAdminSideUC_M();
            PatientForUpdate = ((App)System.Windows.Application.Current).CurrentElements.PatientSelected;
            UpdatePatientDetailes = new UpdatePatientCommand(this);
            Gender = _patientAdminSide_M.Gender;
        }

        public void UpdatePatient()
        {
            _patientAdminSide_M.UpdatePatient(PatientForUpdate);
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
