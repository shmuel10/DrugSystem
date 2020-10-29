using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DrugSystem.Command;

namespace DrugSystem.ViewModels
{
    public class NewVisitUC_VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        bool _chooseMedUCVisibility;
        public ICommand ChooseMedCommand { get; set; }
        public bool ChooseMedUCVisibility {
            get { return _chooseMedUCVisibility; }
            set {
                _chooseMedUCVisibility = value;
                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ChooseMedUCVisibility"));
                }
            }
        }
        public NewVisitUC_VM()
        {
            _chooseMedUCVisibility = false;
            ChooseMedCommand = new ChooseMedicineForPrescriptionCommand(this);
        }
        public Patient CurrentPatient { get; set; }
        public NewVisitUC_VM(Patient currentPatient)
        {
            CurrentPatient = currentPatient;
        }

        public NewVisitUC_VM()
        {
        }
    }
}
