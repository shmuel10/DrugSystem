using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using BLL.BE;
using DrugSystem.Command;
using DrugSystem.Models;

namespace DrugSystem.ViewModels
{
    public class AdminUC_VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        AdminUC_M _adminUC_M { get; set; }
        public ObservableCollection<Doctor> Doctors { get; set; }
        public ObservableCollection<Officer> Officers { get; set; }
        public ObservableCollection<Patient> Patients { get; set; }
        public ObservableCollection<Medicine> Medicines { get; set; }
        public ObservableCollection<string> MedsName { get; set; }

        Doctor _doctorSelected;
        Patient _patientSelected;
        Medicine _medicineSelected;
        Officer _officerSelected;
        public Doctor DoctorSelected {
            get { return _doctorSelected; }
            set {
                _doctorSelected = value;
                if (value.ID != null)
                {
                    ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell =
                        new DoctorAdminSideUC_VM();
                    if (PropertyChanged != null)
                    {
                        ((App)System.Windows.Application.Current).CurrentElements.DoctorSelected = _doctorSelected;
                        PropertyChanged(this, new PropertyChangedEventArgs("DoctorSelected"));
                    }
                }
            }
        }

        public Patient PatientSelected {
            get { return _patientSelected; }
            set {
                _patientSelected = value;
                if (value.ID != null)
                {
                    ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell =
                        new PatientAdminSideUC_VM();
                    if (PropertyChanged != null)
                    {
                        ((App)System.Windows.Application.Current).CurrentElements.PatientSelected = _patientSelected;
                        PropertyChanged(this, new PropertyChangedEventArgs("PatientSelected"));
                    }
                }
            }
        }

        public Medicine MedicineSelected {
            get { return _medicineSelected; }
            set {
                _medicineSelected = value;
                if (value.MedicineID != null)
                {
                    ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell =
                        new MedicineAdminSideUC_VM();
                    if (PropertyChanged != null)
                    {
                        ((App)System.Windows.Application.Current).CurrentElements.MedicineSelected = _medicineSelected;
                        PropertyChanged(this, new PropertyChangedEventArgs("MedicineSelected"));
                    }
                }
            }
        }

        public Officer OfficerSelected {
            get { return _officerSelected; }
            set {
                _officerSelected = value;
                if (value.ID != null)
                {
                    ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell =
                        new OfficerAdminSideUC_VM();
                    if (PropertyChanged != null)
                    {
                        ((App)System.Windows.Application.Current).CurrentElements.OfficerSelected = _officerSelected;
                        PropertyChanged(this, new PropertyChangedEventArgs("OfficerSelected"));
                    }
                }
            }
        }
        public AdminUC_VM()
        {
            _adminUC_M = new AdminUC_M();
            DoctorSelected = new Doctor();
            PatientSelected = new Patient();
            OfficerSelected = new Officer();
            MedicineSelected = new Medicine();
            _doctorSelected = new Doctor();
            _officerSelected = new Officer();
            _patientSelected = new Patient();
            _medicineSelected = new Medicine();
            Doctors = new ObservableCollection<Doctor>(_adminUC_M.Doctors);
            Officers = new ObservableCollection<Officer>(_adminUC_M.Officers);
            Patients = new ObservableCollection<Patient>(_adminUC_M.Patients);
            Medicines = new ObservableCollection<Medicine>(_adminUC_M.Medicines);

            _doctorsCollectionView = CollectionViewSource.GetDefaultView(Doctors);
            _patientCollectionView = CollectionViewSource.GetDefaultView(Patients);
            _officersCollectionView = CollectionViewSource.GetDefaultView(Officers);
            _medsCollectionView = CollectionViewSource.GetDefaultView(Medicines);

            _doctorsCollectionView.Filter = ListsFilter;
            _patientCollectionView.Filter = ListsFilter;
            _officersCollectionView.Filter = ListsFilter;
            _medsCollectionView.Filter = ListsFilter;
            SearchFontSize = 23;
            MedsName = new ObservableCollection<string>(_adminUC_M.MedicinesName);
        }

        public ObservableCollection<KeyValuePair<string, int>> _staristics;
        public ObservableCollection<KeyValuePair<string,int>> Statistics { get { return _staristics; }
            set {
                _staristics = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Statistics"));
            }
        }

        string _medSelected;
        public string MedSelected { get { return _medSelected; }
            set {
                _medSelected = value;
                Statistics = _adminUC_M.GetMedsUses(value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MedSelected"));
            }
        }



        public Dictionary<string, int> B { get; set; }
     
        public double SearchFontSize { get; set; }

        ICollectionView _doctorsCollectionView;
        ICollectionView _patientCollectionView;
        ICollectionView _officersCollectionView;
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
            if (Doctors != null || Officers != null || Patients != null || Medicines != null)
            {
                CollectionViewSource.GetDefaultView(Doctors).Refresh();
                CollectionViewSource.GetDefaultView(Officers).Refresh();
                CollectionViewSource.GetDefaultView(Patients).Refresh();
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
                if (item is Patient)
                {
                    return ((item as Patient).ID?.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                  (item as Patient).FirstName?.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                  (item as Patient).LastName?.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                  (item as Patient).City?.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                  Convert.ToString((item as Patient).Weight)?.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                  (item as Patient).FamilyDoctor?.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0);
                }
                else if (item is Doctor)
                {
                    return ((item as Doctor).ID?.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                 (item as Doctor).FirstName?.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                 (item as Doctor).LastName?.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                 (item as Doctor).City?.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                 (item as Doctor).LicenceNumber?.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                 (item as Doctor).Specialty?.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0);
                }
                else if (item is Officer)
                {
                    return ((item as Officer).ID?.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                 (item as Officer).FirstName?.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                 (item as Officer).LastName?.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                 (item as Officer).City?.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0);
                }
                else
                {
                    return ((item as Medicine).MedicineID?.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                 (item as Medicine).GenericName?.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                 (item as Medicine).CommercialName?.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                 (item as Medicine).Manufacturer?.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                 (item as Medicine).ActiveIngredients?.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                 (item as Medicine).DoseCharacteristics?.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0);
                }
            }
        }
    }
}
