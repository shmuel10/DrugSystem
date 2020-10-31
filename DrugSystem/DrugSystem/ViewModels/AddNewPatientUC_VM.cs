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
using static BLL.BE.AuxiliaryObjects;

namespace DrugSystem.ViewModels
{
    public class AddNewPatientUC_VM :INotifyPropertyChanged
    {
        AddNewPatientUC_M _addNewPatientUC_M;
        public ICommand CreateNewPatientCommand { get; set; }
        public Patient newPatient { get; set; }
        public List<Gender> Gender { get; set; }
        public AddNewPatientUC_VM()
        {
            newPatient = new Patient();
            _addNewPatientUC_M = new AddNewPatientUC_M();
            CreateNewPatientCommand = new CreateNewPatientCommand(this);
            Gender = _addNewPatientUC_M.Gender;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void CreateNewPatient()
        {
            _addNewPatientUC_M.AddNewPatient(newPatient);
        }
    }
}
