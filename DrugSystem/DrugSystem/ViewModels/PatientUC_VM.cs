using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.BE;
using DrugSystem.Models;

namespace DrugSystem.ViewModels
{
    class PatientUC_VM : INotifyPropertyChanged
    {
        PatientUC_M _patientUC_M;
        private ObservableCollection<Visit> _visits;
        public ObservableCollection<Visit> Visits {
            get { return _visits; }
            set {
                _visits = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Visits"));
            }
        }
        private ObservableCollection<Prescription> _prescriptions;
        public ObservableCollection<Prescription> Prescriptions {
            get { return _prescriptions; }
            set {
                _prescriptions = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Prescriptions"));
            }
        }
        //public List<string> MedicinesNames { get { return _patientUC_M.MedicinesNames; } }
        public PatientUC_VM()
        {
            CurrentPatient = ((App)System.Windows.Application.Current).CurrentElements.PatientSelected;
            _patientUC_M = new PatientUC_M(CurrentPatient?.ID);
            Visits = _patientUC_M.Visits;
            Prescriptions = _patientUC_M.Prescriptions;
         }

        Visit _oldVisitSelected;
        public Visit OldVisitSelected {
            get { return _oldVisitSelected; }
            set {
                _oldVisitSelected = value;
                ((App)System.Windows.Application.Current).CurrentElements.VisitSelected = value;
                ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell = new VisitUC_VM();
            }
        }

        Prescription _presSelected;
        public Prescription PresSelected { get { return _presSelected; }
            set {
                _presSelected = value;

                //Pdf = @"C:/Users/User/source/repos/DrugSystem/DrugSystem/DrugSystem/bin/Debug/prescription_305974966.pdf";
                string pdfPath = @"..\..\.." + @"prescription_" + @value.PrescriptionID + @".pdf";
                if (File.Exists(pdfPath))
                {
                    string tempPath = System.IO.Path.GetTempFileName();
                    File.Copy(pdfPath, tempPath, true);
                    Pdf = tempPath;
                   
                }
                
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PresSelected"));
            }
        }


        string _pdf;
        public string Pdf { get { return _pdf; }
            set {
                _pdf = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Pdf"));
            }
        }
     
        public event PropertyChangedEventHandler PropertyChanged;
        private Patient _currentPatient;
        public Patient CurrentPatient {
            get { return _currentPatient; }
            set {
                _currentPatient = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PatientSelected"));
            }
        }
    }
}
