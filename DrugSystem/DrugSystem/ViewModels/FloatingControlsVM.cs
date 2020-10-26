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
    class FloatingControlsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand NewWorkerCommand { get; set; }
        public ICommand NewMedicineCommand { get; set; }
        public FloatingControlsVM()
        {
            NewWorkerCommand = new AddNewWorkerCommand();
            NewMedicineCommand = new NewMedicineCommand();
        }
    }
}
