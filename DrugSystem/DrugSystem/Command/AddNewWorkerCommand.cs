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
    public class AddNewWorkerCommand : ICommand
    {
        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        //public string WorkerToAdd { get; set; }
        //public AddNewWorkerCommand(string workerToAdd)
        //{
        //    WorkerToAdd = workerToAdd;
        //}
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string workerToAdd = parameter as string;
            AddNewWorkerWindow newWorkerWindow = new AddNewWorkerWindow();
            if(workerToAdd.Equals("Doctor"))
            {
                newWorkerWindow.OfficerUC.Visibility = Visibility.Collapsed;
                newWorkerWindow.DoctorUC.Visibility = Visibility.Visible;
            }
            if (workerToAdd.Equals("Officer"))
            {
                newWorkerWindow.OfficerUC.Visibility = Visibility.Visible;
                newWorkerWindow.DoctorUC.Visibility = Visibility.Collapsed;
            }
            newWorkerWindow.Show();
        }
    }
}
