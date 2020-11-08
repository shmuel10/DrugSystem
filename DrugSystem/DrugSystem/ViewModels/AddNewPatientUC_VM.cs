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
using DrugSystem.Validation;
using static BLL.BE.AuxiliaryObjects;

namespace DrugSystem.ViewModels
{
    public class AddNewPatientUC_VM :INotifyPropertyChanged, IDataErrorInfo
    {
        AddNewPatientUC_M _addNewPatientUC_M;
        public ICommand CreateNewPatientCommand { get; set; }
        public Patient newPatient { get; set; }
        public List<Gender> Gender { get; set; }
        Validations Validations;
        public AddNewPatientUC_VM()
        {
            newPatient = new Patient();
            _addNewPatientUC_M = new AddNewPatientUC_M();
            CreateNewPatientCommand = new CreateNewPatientCommand(this);
            Gender = _addNewPatientUC_M.Gender;
            Validations = new Validations();
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
        bool _flag;
        public string ID { get { return newPatient.ID; } set { newPatient.ID = value; _flag = true; } }
        public string FirstName { get { return newPatient.FirstName; } set { newPatient.FirstName = value; _flag = true; } }
        public string LastName { get { return newPatient.LastName; } set { newPatient.LastName = value; _flag = true; } }
        public string PhoneNumber { get { return newPatient.PhoneNumber; } set { newPatient.PhoneNumber = value; _flag = true; } }
        public string EmailAddress { get { return newPatient.EmailAddress; } set { newPatient.EmailAddress = value; _flag = true; } }
        public string City { get { return newPatient.City; } set { newPatient.City = value; _flag = true; } }
        public string Street { get { return newPatient.Street; } set { newPatient.Street = value; _flag = true; } }
        public string BuildingNumber { get { return newPatient.BuildingNumber; } set { newPatient.BuildingNumber = value; _flag = true; } }
        public string FatherName { get { return newPatient.FatherName; } set { newPatient.FatherName = value; _flag = true; } }
        public string FamilyDoctor { get { return newPatient.FamilyDoctor; } set { newPatient.FamilyDoctor = value; _flag = true; } }
        public double Weight { get { return newPatient.Weight; } set { newPatient.Weight = value; _flag = true; } }

        Dictionary<string, string> validationErrors = new Dictionary<string, string>();
        void Validate()
        {
            validationErrors.Clear();
            string errorMessage;
            errorMessage = Validations.ValidateID(ID);
            if (errorMessage != string.Empty)
            {
                validationErrors.Add("ID", errorMessage);
            }
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                validationErrors.Add("FirstName", "יש להזין שם פרטי");
            }
            if (string.IsNullOrWhiteSpace(LastName))
            {
                validationErrors.Add("LastName", "יש להזין שם משפחה");
            }
            if (string.IsNullOrWhiteSpace(FatherName))
            {
                validationErrors.Add("FatherName", "יש להזין שם האב");
            }
            errorMessage = Validations.ValidatePhoneNumber(PhoneNumber);
            if (errorMessage != string.Empty)
            {
                validationErrors.Add("PhoneNumber", errorMessage);
            }
            errorMessage = Validations.ValidateEmailAddress(EmailAddress);
            if (errorMessage != string.Empty)
            {
                validationErrors.Add("EmailAddress", errorMessage);
            }
            if (string.IsNullOrWhiteSpace(FamilyDoctor))
            {
                validationErrors.Add("FamilyDoctor", "יש להזין שם רופא משפחה");
            }
            if (string.IsNullOrWhiteSpace(City))
            {
                validationErrors.Add("City", "יש להזין שם עיר");
            }
            if (string.IsNullOrWhiteSpace(Street))
            {
                validationErrors.Add("Street", "יש להזין שם רחוב");
            }
            if (string.IsNullOrWhiteSpace(BuildingNumber))
            {
                validationErrors.Add("BuildingNumber", "יש להזין מספר בניין");
            }
            errorMessage = Validations.ValidateWeight(Weight.ToString());
            if (errorMessage != string.Empty)
            {
                validationErrors.Add("Weight", errorMessage);
            }

            PropertyChanged(this, new PropertyChangedEventArgs(null));
        }
        public string Error {
            get {
                if (validationErrors.Count > 0)
                {
                    return "Errors found.";
                }
                return null;
            }
        }

        public string this[string columnName] {
            get {
                if (_flag)
                {
                    _flag = false;
                    string errorMessage = string.Empty;
                    switch (columnName)
                    {
                        case "ID":
                            errorMessage = Validations.ValidateID(ID);
                            break;
                        case "FirstName":
                            if (string.IsNullOrWhiteSpace(FirstName))
                                errorMessage = "יש להזין שם פרטי";
                            break;
                        case "LastName":
                            if (string.IsNullOrWhiteSpace(LastName))
                                errorMessage = "יש להזין שם משפחה";
                            break;
                        case "Weight":
                            errorMessage = Validations.ValidateWeight(Weight.ToString());
                            break;
                        case "PhoneNumber":
                            errorMessage = Validations.ValidatePhoneNumber(PhoneNumber);
                            break;
                        case "EmailAddress":
                            errorMessage = Validations.ValidateEmailAddress(EmailAddress);
                            break;
                        case "FatherName":
                            if (string.IsNullOrWhiteSpace(FatherName))
                                errorMessage = "יש להזין שם האב";
                            break;
                        case "City":
                            if (string.IsNullOrWhiteSpace(City))
                                errorMessage = "יש להזין שם עיר";
                            break;
                        case "Street":
                            if (string.IsNullOrWhiteSpace(Street))
                                errorMessage = "יש להזין שם רחוב";
                            break;
                        case "BuildingNumber":
                            if (string.IsNullOrWhiteSpace(BuildingNumber))
                                errorMessage = "יש להזין מספר בניין";
                            break;
                        case "FamilyDoctor":
                            if (string.IsNullOrWhiteSpace(FamilyDoctor))
                                errorMessage = "יש להזין שם רופא המשפחה";
                            break;
                        default:
                            break;
                    }
                    return errorMessage;
                }
                if (validationErrors.ContainsKey(columnName))
                {
                    return validationErrors[columnName];
                }
                return null;
            }
        }

        public void Save()
        {
            Validate();
            if (validationErrors.Count == 0)
            {
                CreateNewPatient();
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
