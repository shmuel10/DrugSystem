using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using BLL.BE;
using DrugSystem.Command;
using DrugSystem.Models;
using DrugSystem.Validation;
using DrugSystem.Views;
using static BLL.BE.AuxiliaryObjects;

namespace DrugSystem.ViewModels
{
    public class AddNewDoctorUC_VM : INotifyPropertyChanged, IDataErrorInfo
    {
        AddNewDoctorUC_M _addNewDoctorUC_M;
        public Doctor newDoctor { get; set; }
        public ICommand CreateNewDoctorCommand { get; set; }
        public ICommand FileDialogCommand { get; set; }
        public List<Gender> Gender { get; set; }
        string _imgSrc;
        public string ImageSrc {
            get { return _imgSrc; }
            set {
                _imgSrc = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImageSrc"));
            }
        }
        private string _errorMessage = string.Empty;
        public string ErrorMessage {
            get { return _errorMessage; }
            set {
                _errorMessage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ErrorMessage"));
            }
        }
        bool _flag;
        public string ID { get { return newDoctor.ID; } set { newDoctor.ID = value; _flag = true; } }
        public string FirstName { get { return newDoctor.FirstName; } set { newDoctor.FirstName = value; _flag = true; } }
        public string LastName { get { return newDoctor.LastName; } set { newDoctor.LastName = value; _flag = true; } }
        public string Password { get { return newDoctor.Password; } set { newDoctor.Password = value; _flag = true; } }
        public string PhoneNumber { get { return newDoctor.PhoneNumber; } set { newDoctor.PhoneNumber = value; _flag = true; } }
        public string EmailAddress { get { return newDoctor.EmailAddress; } set { newDoctor.EmailAddress = value; _flag = true; } }
        public string LicenceNumber { get { return newDoctor.LicenceNumber; } set { newDoctor.LicenceNumber = value; _flag = true; } }
        public string City { get { return newDoctor.City; } set { newDoctor.City = value; _flag = true; } }
        public string Street { get { return newDoctor.Street; } set { newDoctor.Street = value; _flag = true; } }
        public string BuildingNumber { get { return newDoctor.BuildingNumber; } set { newDoctor.BuildingNumber = value; _flag = true; } }
        public string Specialty { get { return newDoctor.Specialty; } set { newDoctor.Specialty = value; _flag = true; } }
        
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
            errorMessage = Validations.ValidatePassword(Password);
            if (errorMessage != string.Empty)
            {
                validationErrors.Add("Password", errorMessage);
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
            if (string.IsNullOrWhiteSpace(LicenceNumber))
            {
                validationErrors.Add("LicenceNumber", "יש להזין מספר רישיון");
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
              if (string.IsNullOrWhiteSpace(Specialty))
            {
                validationErrors.Add("Specialty", "יש להזין מומחיות");
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
                    switch (columnName) {
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
                        case "Password":
                            errorMessage = Validations.ValidatePassword(Password);
                            break;
                        case "PhoneNumber":
                            errorMessage = Validations.ValidatePhoneNumber(PhoneNumber);
                            break;
                        case "EmailAddress":
                            errorMessage = Validations.ValidateEmailAddress(EmailAddress);
                            break;
                        case "LicenceNumber":
                            if (string.IsNullOrWhiteSpace(LicenceNumber))
                                errorMessage = "יש להזין מספר רישיון";
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
                        case "Specialty":
                            if (string.IsNullOrWhiteSpace(Specialty))
                                errorMessage = "יש להזין מומחיות";
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
                CreateNewDoctor();
            }
        }

        Validations Validations;
        public AddNewDoctorUC_VM()
        {
            _addNewDoctorUC_M = new AddNewDoctorUC_M();
            Gender = _addNewDoctorUC_M.Gender;
            CreateNewDoctorCommand = new CreateNewDoctorCommand(this);
            FileDialogCommand = new OpenFileDialogCommand(this);
            newDoctor = new Doctor();
            ImageSrc = @"/Icons/UserIcon.jpg";
            Validations = new Validations();
            _flag = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void CreateNewDoctor()
        {
            try
            {
                _addNewDoctorUC_M.AddNewDoctor(newDoctor);
                ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell =
    ((App)System.Windows.Application.Current).CurrentElements.StackOnShell.Peek();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}