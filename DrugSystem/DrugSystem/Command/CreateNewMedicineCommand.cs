using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace DrugSystem
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
            return ((AddNewMedicineWindow_VM)CurrentVM).MedicineExistInXML(parameter as string);
        }

        public void Execute(object parameter)
        {
            ((AddNewMedicineWindow_VM)CurrentVM).CreateNewDoctor();
            AddNewMedicineWindow win = ((App)System.Windows.Application.Current).Windows.OfType<AddNewMedicineWindow>().FirstOrDefault();
            if (win != null)
            {
                win.Close();
            }
        }
    }
}