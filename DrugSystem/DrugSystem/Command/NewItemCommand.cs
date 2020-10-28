using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DrugSystem.Windows;

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
            return true;
        }

        public void Execute(object parameter)
        {
            string workerToAdd = parameter as string;
            AddNewUserWindow newWorkerWindow = new AddNewUserWindow();
            if(workerToAdd.Equals("Doctor"))
            {
                newWorkerWindow.OfficerUC.Visibility = Visibility.Collapsed;
                newWorkerWindow.PatientUC.Visibility = Visibility.Collapsed;
                newWorkerWindow.DoctorUC.Visibility = Visibility.Visible;
            }
            if (workerToAdd.Equals("Officer"))
            {
                newWorkerWindow.DoctorUC.Visibility = Visibility.Collapsed;
                newWorkerWindow.PatientUC.Visibility = Visibility.Collapsed;
                newWorkerWindow.OfficerUC.Visibility = Visibility.Visible;
            }
            if (workerToAdd.Equals("Patient"))
            {
                newWorkerWindow.OfficerUC.Visibility = Visibility.Collapsed;
                newWorkerWindow.DoctorUC.Visibility = Visibility.Collapsed;
                newWorkerWindow.PatientUC.Visibility = Visibility.Visible;
            }
            newWorkerWindow.Show();
        }
    }
}
