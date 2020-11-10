using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using BLL.BE;
using DrugSystem.Command;
using DrugSystem.Models;

namespace DrugSystem.ViewModels
{
    public class DoctorUC_VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DoctorUC_M _doctorUC_M;
        public Patient _selectedPatient;

        public ICommand Command { get; set; }
        public List<Patient> Patients { get { return _doctorUC_M.Patients; } }
        public Patient SelectedPatient {
            get { return _selectedPatient; }
            set {
                _selectedPatient = value;
                if (value.ID != null)
                {
                    ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell =
                        new PatientUC_VM();
                    if (PropertyChanged != null)
                    {
                        ((App)System.Windows.Application.Current).CurrentElements.PatientSelected = _selectedPatient;
                        PropertyChanged(this, new PropertyChangedEventArgs("SelectedPatient"));
                    }
                }
            }
        }

        public double SearchFontSize { get; set; }

        ICollectionView _patientCollectionView;
        string _search;
        public string Search {
            get { return _search; }
            set {
                _search = value;
                PropRaised();
            }
        }

        public DoctorUC_VM()
        {
            Command = new NewItemCommand();
            _doctorUC_M = new DoctorUC_M();
            _selectedPatient = new Patient();
            SelectedPatient = new Patient();
            _patientCollectionView = CollectionViewSource.GetDefaultView(Patients);
            _patientCollectionView.Filter = PatientListFilter;
            SearchFontSize = 23;
        }

        private void PropRaised()
        {
            if (Patients != null)
            {
                CollectionViewSource.GetDefaultView(Patients).Refresh();
            }
        }

        private bool PatientListFilter(object item)
        {
            if (String.IsNullOrEmpty(Search))
                return true;
            else
                return ((item as Patient).ID.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   (item as Patient).FirstName.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   (item as Patient).LastName.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   (item as Patient).City.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   Convert.ToString((item as Patient).Weight).IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   (item as Patient).FamilyDoctor.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}
