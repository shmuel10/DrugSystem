using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
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
        public Visit NewVisit { get; set; }
        List<string> interactionList;
        public List<string> Medicines { get { return _newVisitUC_M.Medicines; } }
        string _medicalCare = "";
        public string MedicalCare {
            get { return _medicalCare; }
            set {
                _medicalCare += value;
                PropertyChanged(this, new PropertyChangedEventArgs("MedicalCare"));
            }
        }
        string _selectedMedName;
        public string SelectedMedName { get { return _selectedMedName; } set { _selectedMedName = value;
                _medicalCare = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MedicalCare"));
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedMedName"));
                SelectedMedicineCode = _newVisitUC_M.GetMedicineCode(value);
                _interactionsMedicinesNames.Clear();
                interactionList = _newVisitUC_M.BL.GetInteractionMedicines(CurrentPatient.ID, SelectedMedName, SelectedMedicineCode);
                if (interactionList?.Count > 0)
                {
                    _interactionsMedicinesNames.Add("קיימת התנגשות עם:\n");
                    foreach (string item in interactionList)
                    {
                        _interactionsMedicinesNames.Add(item);
                    }
                    IteractionMedicineVisibility = true;
                    PropertyChanged(this, new PropertyChangedEventArgs("InteractionsMedicinesNames"));
                }
            }
        }
        private string _selectedMedicinesCode;
        public string SelectedMedicineCode { get { return _selectedMedicinesCode; }
            set {
                _selectedMedicinesCode = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedMedicineCode"));
            }
        }
        private ObservableCollection<string> _interactionsMedicinesNames;
        public ObservableCollection<string> InteractionsMedicinesNames {
            get { return _interactionsMedicinesNames; }
            set { }
        }
        public ICommand CreatePrescripton { get; set; }

        public ICommand ChooseMedCommand { get; set; }

        public NewVisitUC_VM()
        {
            _newVisitUC_M = new NewVisitUC_M();
            _prescription = new Prescription();
            NewVisit = new Visit();
            CreatePrescripton = new SaveVisitCommand(this);
            ChooseMedUCVisibility = false;
            interactionList = new List<string>();
            _interactionsMedicinesNames = new ObservableCollection<string>();
            ChooseMedCommand = new ChooseMedicineForPrescriptionCommand(this);
            if (((App)Application.Current).CurrentElements.StackOnShell.Count > 1)
            {
                CurrentPatient = ((App)Application.Current).CurrentElements.PatientSelected;
            }
           
            _medsCollectionView = CollectionViewSource.GetDefaultView(Medicines);
            _medsCollectionView.Filter = ListsFilter;

            IteractionMedicineVisibility = false;
        }

        bool _redBorder;
        public bool IteractionMedicineVisibility { get { return _redBorder; }
            set {
                _redBorder = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IteractionMedicineVisibility"));
            }
        }

        ICollectionView _medsCollectionView;

        string _search;
        public string Search {
            get { return _search; }
            set {
                _search = value;
                PropRaised();
            }
        }

        private void PropRaised()
        {
            if (Medicines != null)
            {
                CollectionViewSource.GetDefaultView(Medicines).Refresh();
            }
        }

        private bool ListsFilter(object item)
        {
            if (String.IsNullOrEmpty(Search))
            {
                return true;
            }
            else
            {
                return ((item as string).IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0);
            }
        }
   
        public Patient CurrentPatient {
            get { return _currentPatient; }
            set {
                _currentPatient = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PatientSelected"));
            }
        }

        public bool ChooseMedUCVisibility {
            get { return _chooseMedUCVisibility; }
            set {
                _chooseMedUCVisibility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ChooseMedUCVisibility"));
            }
        }
        private string _errorMessage = string.Empty;
        public string ErrorMessage {
            get { return _errorMessage; }
            set {
                _errorMessage = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ErrorMessage"));
            }
        }
        public void SavePrescription()
        {
            try
            {
                Doctor doctor = ((App)System.Windows.Application.Current).CurrentElements.CurrentUser as Doctor;
                string serialNuber = _newVisitUC_M.GeneratePrescriptionSerialNumber();
                if (MedicalCare.Length > 0)
                {
                    _prescription.DoctorID = doctor.ID;
                    _prescription.ExpireDate = DateTime.Now.AddDays(90);
                    _prescription.PatientID = _currentPatient.ID;
                    _prescription.StartDate = DateTime.Now;
                    _prescription.MedicineCode = SelectedMedicineCode;
                    _prescription.Instructions = MedicalCare;
                    _prescription.PrescriptionID = serialNuber;
                    _newVisitUC_M.AddPrescription(_prescription);
                }
                NewVisit.VisitID = serialNuber;
                NewVisit.DoctorID = doctor.ID;
                NewVisit.PrescriptionID = serialNuber;
                NewVisit.PatientID = _currentPatient.ID;
                NewVisit.VisitDate = DateTime.Now;
                _newVisitUC_M.AddVisit(NewVisit);
                WpfToPdf wpfToPdf = new WpfToPdf(_prescription);
                ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell =
    ((App)System.Windows.Application.Current).CurrentElements.StackOnShell.Peek();
            }
            catch(Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
