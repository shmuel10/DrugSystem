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
        private string _errorMessage = string.Empty;
        public string ErrorMessage {
            get { return _errorMessage; }
            set {
                _errorMessage = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ErrorMessage"));
            }
        }
        public void CreateNewPatient()
        {
            try
            {
                _addNewPatientUC_M.AddNewPatient(newPatient);
                ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell =
    ((App)System.Windows.Application.Current).CurrentElements.StackOnShell.Peek();
            }
            catch(Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
