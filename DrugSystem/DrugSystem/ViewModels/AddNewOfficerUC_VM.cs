using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using BLL.BE;
using DrugSystem.Command;
using DrugSystem.Models;
using DrugSystem.Validation;
using static BLL.BE.AuxiliaryObjects;

namespace DrugSystem.ViewModels
{
    public class AddNewOfficerUC_VM : INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;
        AddNewOfficerUC_M _addNewOfficerUC_M;
        public Officer newOfficer { get; set; }
        public ICommand CreateNewOfficerCommand { get; set; }
        public ICommand FileDialogCommand { get; set; }
        public List<Gender> Gender { get; set; }
        public DateTime StartDate { get { return DateTime.Now.AddYears(-70); } set { } }
        public DateTime EndDate { get { return DateTime.Now.AddYears(-17); } set { } }


        string _imgSrc;
        public string ImageSrc {
            get { return _imgSrc; }
            set {
                _imgSrc = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImageSrc"));
            }
        }
        Validations Validations;
        public AddNewOfficerUC_VM()
        {
            _addNewOfficerUC_M = new AddNewOfficerUC_M();
            CreateNewOfficerCommand = new CreateNewOfficerCommand(this);
            FileDialogCommand = new OpenFileDialogCommand(this);
            Gender = _addNewOfficerUC_M.Gender;
            newOfficer = new Officer();
            ImageSrc = @"/Icons/UserIcon.jpg";
            Validations = new Validations();
            _flag = false;
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
        public string ID { get { return newOfficer.ID; } set { newOfficer.ID = value; _flag = true; } }
        public string FirstName { get { return newOfficer.FirstName; } set { newOfficer.FirstName = value; _flag = true; } }
        public string LastName { get { return newOfficer.LastName; } set { newOfficer.LastName = value; _flag = true; } }
        public string Password { get { return newOfficer.Password; } set { newOfficer.Password = value; _flag = true; } }
        public string PhoneNumber { get { return newOfficer.PhoneNumber; } set { newOfficer.PhoneNumber = value; _flag = true; } }
        public string EmailAddress { get { return newOfficer.EmailAddress; } set { newOfficer.EmailAddress = value; _flag = true; } }
        public string City { get { return newOfficer.City; } set { newOfficer.City = value; _flag = true; } }
        public string Street { get { return newOfficer.Street; } set { newOfficer.Street = value; _flag = true; } }
        public string BuildingNumber { get { return newOfficer.BuildingNumber; } set { newOfficer.BuildingNumber = value; _flag = true; } }

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
                        case "Password":
                            errorMessage = Validations.ValidatePassword(Password);
                            break;
                        case "PhoneNumber":
                            errorMessage = Validations.ValidatePhoneNumber(PhoneNumber);
                            break;
                        case "EmailAddress":
                            errorMessage = Validations.ValidateEmailAddress(EmailAddress);
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
                CreateNewOfficer();
            }
        }

        public void CreateNewOfficer()
        {
            try
            {
                _addNewOfficerUC_M.AddNewOfficer(newOfficer);
                ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell =
    ((App)System.Windows.Application.Current).CurrentElements.StackOnShell.Peek();
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("מספר זהות כבר שמור במערכת"))
                {
                    validationErrors.Add("ID", ex.Message);
                    PropertyChanged(this, new PropertyChangedEventArgs(null));
                    validationErrors.Remove("ID");
                    ErrorMessage = "ישנם שדות לא תקינים";
                }
                else if (ex.Message.Equals("כתובת המייל כבר שמורה במערכת"))
                {
                    validationErrors.Add("EmailAddress", ex.Message);
                    PropertyChanged(this, new PropertyChangedEventArgs(null));
                    validationErrors.Remove("EmailAddress");
                    ErrorMessage = "ישנם שדות לא תקינים";
                }
                else
                {
                    ErrorMessage = ex.Message;
                }
            }
        }
    }
}