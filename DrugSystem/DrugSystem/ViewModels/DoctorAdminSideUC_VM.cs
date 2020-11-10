using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using BLL.BE;
using DrugSystem.Command;
using DrugSystem.Models;
using DrugSystem.Validation;
using static BLL.BE.AuxiliaryObjects;

namespace DrugSystem.ViewModels
{
    public class DoctorAdminSideUC_VM : INotifyPropertyChanged, IDataErrorInfo
    {
        DoctorAdminSideUC_M _doctorAdminSideUC_M;
        public ICommand FileDialogCommand { get; set; }
        public ICommand UpdateDoctorDetailes { get; set; }
        public List<Gender> Gender { get; set; }
        public Doctor DoctorForUpdate { get; set; }
        BitmapImage _imageSrc;
        public BitmapImage ImageSrc { get { return _imageSrc; }
            set { _imageSrc = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImageSrc"));
            }
        }
        public DoctorAdminSideUC_VM()
        {
            _doctorAdminSideUC_M = new DoctorAdminSideUC_M();
            DoctorForUpdate = ((App)System.Windows.Application.Current).CurrentElements.DoctorSelected;
            if (DoctorForUpdate != null)
            {
                if (File.Exists(DoctorForUpdate.ProfileImagePath))
                {
                    string tempPath = System.IO.Path.GetTempFileName();
                    File.Copy(DoctorForUpdate.ProfileImagePath, tempPath, true);
                    ImageSrc = new BitmapImage(new Uri(tempPath));
                }
            }
            Validations = new Validations();
            UpdateDoctorDetailes = new UpdateDoctorCommand(this);
            FileDialogCommand = new OpenFileDialogCommand(this);
            Gender = _doctorAdminSideUC_M.Gender;
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
        public string FirstName { get { return DoctorForUpdate.FirstName; } set { DoctorForUpdate.FirstName = value; _flag = true; } }
        public string LastName { get { return DoctorForUpdate.LastName; } set { DoctorForUpdate.LastName = value; _flag = true; } }
        public string Password { get { return DoctorForUpdate.Password; } set { DoctorForUpdate.Password = value; _flag = true; } }
        public string PhoneNumber { get { return DoctorForUpdate.PhoneNumber; } set { DoctorForUpdate.PhoneNumber = value; _flag = true; } }
        public string EmailAddress { get { return DoctorForUpdate.EmailAddress; } set { DoctorForUpdate.EmailAddress = value; _flag = true; } }
        public string LicenceNumber { get { return DoctorForUpdate.LicenceNumber; } set { DoctorForUpdate.LicenceNumber = value; _flag = true; } }
        public string City { get { return DoctorForUpdate.City; } set { DoctorForUpdate.City = value; _flag = true; } }
        public string Street { get { return DoctorForUpdate.Street; } set { DoctorForUpdate.Street = value; _flag = true; } }
        public string BuildingNumber { get { return DoctorForUpdate.BuildingNumber; } set { DoctorForUpdate.BuildingNumber = value; _flag = true; } }
        public string Specialty { get { return DoctorForUpdate.Specialty; } set { DoctorForUpdate.Specialty = value; _flag = true; } }

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
                UpdateDoctor();
            }
        }

        Validations Validations;
        public void UpdateDoctor()
        {
            try
            {
                _doctorAdminSideUC_M.UpdateDoctor(DoctorForUpdate);
                ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell =
    ((App)System.Windows.Application.Current).CurrentElements.StackOnShell.Peek();

            }
            catch (Exception ex)
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
