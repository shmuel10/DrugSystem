using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BLL.BE;
using DrugSystem.Command;
using DrugSystem.Models;
using DrugSystem.Views;

namespace DrugSystem.ViewModels
{
    public class NewVisitUC_VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        bool _chooseMedUCVisibility;
        NewVisitUC_M _newVisitUC_M;
        Patient _currentPatient;
        Prescription _prescription;
        public ICommand CreatePrescripton { get; set; }
        string _treatmentDetails;
        public ICommand ChooseMedCommand { get; set; }
        public string TreatmentDetails { get { return _treatmentDetails; }
            set {
                _treatmentDetails = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TreatmentDetails"));
            }
        }
        public NewVisitUC_VM()
        {
            _newVisitUC_M = new NewVisitUC_M();
            _prescription = new Prescription();
            CreatePrescripton = new SaveVisitCommand(this);
            ChooseMedUCVisibility = false;
            ChooseMedCommand = new ChooseMedicineForPrescriptionCommand(this);
            if (((App)System.Windows.Application.Current).CurrentElements.StackOnShell.Count > 1)
                CurrentPatient = ((App)System.Windows.Application.Current).CurrentElements.CurrentPatient;
        }

        public Patient CurrentPatient {
            get { return _currentPatient; }
            set {
                _currentPatient = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentPatient"));
            }
        }

        public bool ChooseMedUCVisibility {
            get { return _chooseMedUCVisibility; }
            set {
                _chooseMedUCVisibility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ChooseMedUCVisibility"));
            }
        }

        public void SavePrescription()
        {
            Doctor doctor = ((App)System.Windows.Application.Current).CurrentElements.CurrentUser as Doctor;
            _prescription.DoctorID = doctor.ID;
            _prescription.ExpireDate = DateTime.Now.AddDays(90);
            _prescription.PatientID = _currentPatient.ID;
            _prescription.StartDate = DateTime.Now;
            _prescription.Instructions = TreatmentDetails;
            _newVisitUC_M.AddPrescription(_prescription);
        }
    }
}
