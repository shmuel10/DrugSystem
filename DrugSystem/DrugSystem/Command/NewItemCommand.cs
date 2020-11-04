using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BLL.BE;
using DrugSystem.ViewModels;
using DrugSystem.Views;

namespace DrugSystem.Command
{
    public class NewItemCommand : ICommand
    {
        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
       
        public bool CanExecute(object parameter)
        {
            if (((App)System.Windows.Application.Current).CurrentElements.CurrentUser is Administrator)
            {
                return true;
            }
            else
            {
                if (((App)System.Windows.Application.Current).CurrentElements.CurrentUser.CanAddDoctor &&
                    parameter.Equals("Doctor"))
                {
                    return true;
                }
                if (((App)System.Windows.Application.Current).CurrentElements.CurrentUser.CanAddMedicine &&
                    parameter.Equals("Medicine"))
                {
                    return true;
                }
                if (((App)System.Windows.Application.Current).CurrentElements.CurrentUser.CanAddPatient &&
                    parameter.Equals("Patient"))
                {
                    return true;
                }
                return false;
            }        
        }

        public void Execute(object parameter)
        {
            (((App)System.Windows.Application.Current).CurrentElements.CurrentViewModel as ShellUC_VM).StatusBar = "GGG";

            string workerToAdd = parameter as string;
            if (workerToAdd.Equals("Doctor"))
            {
                ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell =
                    new AddNewDoctorUC_VM();
            }
            if (workerToAdd.Equals("Officer"))
            {
                ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell =
                    new AddNewOfficerUC_VM();
            }
            if (workerToAdd.Equals("Patient"))
            {
                ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell =
                    new AddNewPatientUC_VM();
            }
            if (workerToAdd.Equals("Medicine"))
            {
                ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell =
                    new AddNewMedicineUC_VM();
            }
        }
    }
}
