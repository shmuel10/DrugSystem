using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DrugSystem.Command
{
    public class AddNewMedicineCommand : ICommand
    {
        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public INotifyPropertyChanged CurrentVM { get; set; }

        public AddNewMedicineCommand(INotifyPropertyChanged currentVM)
        {
            CurrentVM = currentVM;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //((AddNewMedicineWindow)CurrentVM).AddMedicine();
            //((AddNewMedicineWindow)CurrentVM).CreateNewDoctor();
            AddNewMedicineWindow win = ((App)System.Windows.Application.Current).Windows.OfType<AddNewMedicineWindow>().FirstOrDefault();
            if (win != null)
            {
                win.Close();
            }
            win = ((App)System.Windows.Application.Current).Windows.OfType<AddNewMedicineWindow>().FirstOrDefault();
            if (win != null)
            {
                win.Close();
            }
        }
    }
}
