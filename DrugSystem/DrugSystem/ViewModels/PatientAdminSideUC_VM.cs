using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    public class PatientAdminSideUC_VM : INotifyPropertyChanged, IDataErrorInfo
    {
        PatientAdminSideUC_M _patientAdminSide_M;
        public ICommand UpdatePatientDetailes { get; set; }
        public List<Gender> Gender { get; set; }
        public Patient PatientForUpdate { get; set; }
        Validations Validations;
        public PatientAdminSideUC_VM()
        {
            _patientAdminSide_M = new PatientAdminSideUC_M();
            PatientForUpdate = ((App)System.Windows.Application.Current).CurrentElements.PatientSelected;
            UpdatePatientDetailes = new UpdatePatientCommand(this);
            Gender = _patientAdminSide_M.Gender;
            Validations = new Validations();
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
        public string FirstName { get { return PatientForUpdate.FirstName; } set { PatientForUpdate.FirstName = value; _flag = true; } }
        public string LastName { get { return PatientForUpdate.LastName; } set { PatientForUpdate.LastName = value; _flag = true; } }
        public string PhoneNumber { get { return PatientForUpdate.PhoneNumber; } set { PatientForUpdate.PhoneNumber = value; _flag = true; } }
        public string EmailAddress { get { return PatientForUpdate.EmailAddress; } set { PatientForUpdate.EmailAddress = value; _flag = true; } }
        public string City { get { return PatientForUpdate.City; } set { PatientForUpdate.City = value; _flag = true; } }
        public string Street { get { return PatientForUpdate.Street; } set { PatientForUpdate.Street = value; _flag = true; } }
        public string BuildingNumber { get { return PatientForUpdate.BuildingNumber; } set { PatientForUpdate.BuildingNumber = value; _flag = true; } }
        public string FatherName { get { return PatientForUpdate.FatherName; } set { PatientForUpdate.FatherName = value; _flag = true; } }
        public string FamilyDoctor { get { return PatientForUpdate.FamilyDoctor; } set { PatientForUpdate.FamilyDoctor = value; _flag = true; } }
        public double Weight { get { return PatientForUpdate.Weight; } set { PatientForUpdate.Weight = value; _flag = true; } }

        Dictionary<string, string> validationErrors = new Dictionary<string, string>();
        void Validate()
        {
            validationErrors.Clear();
            string errorMessage;
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
                UpdatePatient();
            }
        }

        public void UpdatePatient()
        {
            try
            {
                _patientAdminSide_M.UpdatePatient(PatientForUpdate);
                ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell =
    ((App)System.Windows.Application.Current).CurrentElements.StackOnShell.Peek();
            }
            catch(Exception ex)
            {
                if (ex.Message.Equals("כתובת המייל כבר שמורה במערכת"))
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
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
