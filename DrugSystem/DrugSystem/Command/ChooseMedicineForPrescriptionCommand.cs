using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DrugSystem.ViewModels;

namespace DrugSystem.Command
{
    public class ChooseMedicineForPrescriptionCommand : ICommand
    {
        public INotifyPropertyChanged CurrentVM { get; set; }

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public ChooseMedicineForPrescriptionCommand(INotifyPropertyChanged currentVM)
        {
            CurrentVM = currentVM;
        }
        public bool CanExecute(object parameter)
        {
            return true; 
        }

        public void Execute(object parameter)
        {
            NewVisitUC_VM newVisitUC_VM = CurrentVM as NewVisitUC_VM;
            if(newVisitUC_VM.ChooseMedUCVisibility)
            {
                newVisitUC_VM.ChooseMedUCVisibility = false;
            }
            else
            {
                newVisitUC_VM.ChooseMedUCVisibility = true;
            }
        }
    }
}
