using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using BLL.BE;
using DrugSystem.ViewModels;

namespace DrugSystem.Command
{
    public class CreateNewMedicineCommand : ICommand
    {
        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public INotifyPropertyChanged CurrentVM { get; set; }

        public CreateNewMedicineCommand(INotifyPropertyChanged currentVM)
        {
            CurrentVM = currentVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        

        public void Execute(object parameter)
        {
            ((AddNewMedicineUC_VM)CurrentVM).Save();

        }
    }
}