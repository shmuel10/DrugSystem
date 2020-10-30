using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BLL.BE;
using DrugSystem.Command;

namespace DrugSystem.ViewModels
{
    public class NewVisitUC_VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        bool _chooseMedUCVisibility;
        Patient _currentPatient;

        public Patient CurrentPatient {
            get { return _currentPatient; }
            set {
                _currentPatient = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentPatient"));
            }
        }

        public ICommand ChooseMedCommand { get; set; }
        public bool ChooseMedUCVisibility {
            get { return _chooseMedUCVisibility; }
            set {
                _chooseMedUCVisibility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ChooseMedUCVisibility"));
            }
        }

        public NewVisitUC_VM()
        {
            _chooseMedUCVisibility = false;
            ChooseMedCommand = new ChooseMedicineForPrescriptionCommand(this);
            if (((App)System.Windows.Application.Current).CurrentElements.StackOnShell.Count > 1)
                CurrentPatient = ((App)System.Windows.Application.Current).CurrentElements.CurrentPatient;
        }
    }
}
