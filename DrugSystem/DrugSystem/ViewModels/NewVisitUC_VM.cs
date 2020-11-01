using System;
using System.Collections;
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
        public List<string> Medicines { get { return _newVisitUC_M.Medicines; } }
        
        string _selectedMed = "";
        public string SelectedMed { get { return _selectedMed; } set { _selectedMed += "\n" + value + " ";
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedMed"));
                _selectedMedicinesCodes.Add(_newVisitUC_M.GetMedicineCode(value));
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedMedicinesCodes"));
                List<string> list = _newVisitUC_M.BL.GetInteractionMedicines(CurrentPatient.ID, _newVisitUC_M.GetMedicineCode(value));
                foreach (string item in list)
                {
                    _interactionsMedicinesNames.Add(item);
                }
                PropertyChanged(this, new PropertyChangedEventArgs("InteractionsMedicinesNames"));
            }
        }
        private ObservableCollection<string> _selectedMedicinesCodes;
        public ObservableCollection<string> SelectedMedicinesCodes { get { return _selectedMedicinesCodes; }
            set {  } }
        private ObservableCollection<string> _interactionsMedicinesNames;
        public ObservableCollection<string> InteractionsMedicinesNames {
            get { return _interactionsMedicinesNames; }
            set { }
        }
        public List<string> Interactions { get; set; }
        public ICommand CreatePrescripton { get; set; }
      
        public ICommand ChooseMedCommand { get; set; }
      
        public NewVisitUC_VM()
        {
            _newVisitUC_M = new NewVisitUC_M();
            _prescription = new Prescription();
            CreatePrescripton = new SaveVisitCommand(this);
            ChooseMedUCVisibility = false;
            _selectedMedicinesCodes = new ObservableCollection<string>();
            _interactionsMedicinesNames = new ObservableCollection<string>();
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
            _prescription.MedicineCode = _newVisitUC_M.GetMedicineCode(SelectedMed);
            _prescription.Instructions = SelectedMed;
            _newVisitUC_M.AddPrescription(_prescription);
        }
    }
}
