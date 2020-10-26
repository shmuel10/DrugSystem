using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DrugSystem.Command;

namespace DrugSystem.ViewModels
{
    public class ShellWindowVM
    {
        //public ICommand NewDoctorCommand { get; set; }
        //public ICommand NewOfficerCommand { get; set; }
        public ICommand NewMedicineCommand { get; set; }
        public ICommand NewPatientCommand { get; set; }
        public ICommand SignOutCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand NewWorkerCommand { get; set; }


        public ShellWindowVM()
        {
            //NewDoctorCommand = new NewDoctorCommand();
            //NewOfficerCommand = new NewOfficerCommand();
            NewWorkerCommand = new AddNewWorkerCommand();
            NewMedicineCommand = new NewMedicineCommand();
            NewPatientCommand = new AddNewPatientCommand();
            SignOutCommand = new SignOutCommand();
            ExitCommand = new ExitCommand();
        }
    }
}
