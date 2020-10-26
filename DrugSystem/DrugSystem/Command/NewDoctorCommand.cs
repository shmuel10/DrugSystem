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
    public class NewDoctorCommand : ICommand
    {
        public INotifyPropertyChanged CurrentVM { get; set; }

        public NewDoctorCommand(INotifyPropertyChanged adminUC)
        {
            CurrentVM = adminUC;
        }

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
            AddNewDoctor newDoctor = new AddNewDoctor();
            newDoctor.Show();
        }
    }
}
