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
    public class ShellWindowVM : INotifyPropertyChanged
    {
        public ICommand NewMedicineCommand { get; set; }
        public ICommand NewPatientCommand { get; set; }
        public ICommand SignOutCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand NewWorkerCommand { get; set; }


        public ShellWindowVM()
        {
            NewWorkerCommand = new NewItemCommand();
            NewMedicineCommand = new NewMedicineCommand();
            NewPatientCommand = new NewPatientCommand();
            SignOutCommand = new SignOutCommand();
            ExitCommand = new ExitCommand();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
