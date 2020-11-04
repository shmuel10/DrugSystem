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
            if ((((App)System.Windows.Application.Current).CurrentElements.CurrentUser) is Administrator)
            {
                return true;
            }
            else
            {
                if (((App)System.Windows.Application.Current).CurrentElements.CurrentUser.CanAddMedicine)
                {
                    if (((AddNewMedicineUC_VM)CurrentVM).MedicineExistInXML(parameter as string))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public void Execute(object parameter)
        {
            ((AddNewMedicineUC_VM)CurrentVM).CreateNewDoctor();
            ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell =
                ((App)System.Windows.Application.Current).CurrentElements.StackOnShell.Peek();
        }
    }
}