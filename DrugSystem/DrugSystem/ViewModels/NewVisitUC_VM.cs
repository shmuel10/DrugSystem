using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
                _medicalCare = "";
                PropertyChanged(this, new PropertyChangedEventArgs("MedicalCare"));
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedMedName"));
                SelectedMedicineCode = _newVisitUC_M.GetMedicineCode(value);
                _interactionsMedicinesNames.Clear();
                interactionList = _newVisitUC_M.BL.GetInteractionMedicines(CurrentPatient.ID, SelectedMedName, SelectedMedicineCode);
                if (interactionList != null)
                {
                    foreach (string item in interactionList)
                    {
                        _interactionsMedicinesNames.Add(item);
                    }
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
            CreatePrescripton = new SaveVisitCommand(this);
            ChooseMedUCVisibility = false;
            interactionList = new List<string>();
            _interactionsMedicinesNames = new ObservableCollection<string>();
            ChooseMedCommand = new ChooseMedicineForPrescriptionCommand(this);
            if (((App)System.Windows.Application.Current).CurrentElements.StackOnShell.Count > 1)
            {
                CurrentPatient = ((App)System.Windows.Application.Current).CurrentElements.PatientSelected;
            }
            SearchFontSize = 10;
            _medsCollectionView = CollectionViewSource.GetDefaultView(Medicines);
            _medsCollectionView.Filter = ListsFilter;
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
    
        public double SearchFontSize { get; set; }
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

        public void SavePrescription()
        {
            Doctor doctor = ((App)System.Windows.Application.Current).CurrentElements.CurrentUser as Doctor;
            _prescription.DoctorID = doctor.ID;
            _prescription.ExpireDate = DateTime.Now.AddDays(90);
            _prescription.PatientID = _currentPatient.ID;
            _prescription.StartDate = DateTime.Now;
            _prescription.MedicineCode = SelectedMedicineCode;
            _prescription.Instructions = InteractionsMedicinesNames.ToString();
            _newVisitUC_M.AddPrescription(_prescription);
        }
    }
}
