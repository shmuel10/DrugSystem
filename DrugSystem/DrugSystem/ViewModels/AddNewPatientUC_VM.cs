using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BLL.BE;
using DrugSystem.Command;
using DrugSystem.Models;

namespace DrugSystem.ViewModels
{
    public class AddNewPatientUC_VM :INotifyPropertyChanged
    {
        public AddNewPatientUC_M AddNewPatientUC_M { get; set; }
        public ICommand CreateNewPatientCommand { get; set; }
        public Patient newPatient { get; set; }
        public AddNewPatientUC_VM()
        {
            newPatient = new Patient();
            AddNewPatientUC_M = new AddNewPatientUC_M();
            CreateNewPatientCommand = new CreateNewPatientCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void CreateNewPatient()
        {
            AddNewPatientUC_M.AddNewPatient(newPatient);
        }
    }
}
