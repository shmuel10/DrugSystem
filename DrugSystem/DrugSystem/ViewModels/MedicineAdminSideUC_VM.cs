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
using static BLL.BE.AuxiliaryObjects;

namespace DrugSystem.ViewModels
{
    public class MedicineAdminSideUC_VM : INotifyPropertyChanged, IDataErrorInfo
    {
        MedicineAdminSide_M _medicineAdminSide_M;
        public ICommand FileDialogCommand { get; set; }
        public ICommand UpdateMedDetailes { get; set; }
        public List<Gender> Gender { get; set; }
        public Medicine MedicineForUpdate { get; set; }
        BitmapImage _imageSrc;
        public BitmapImage ImageSrc {
            get { return _imageSrc; }
            set {
                _imageSrc = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImageSrc"));
            }
        }

        public MedicineAdminSideUC_VM()
        {
            _medicineAdminSide_M = new MedicineAdminSide_M();
            MedicineForUpdate = ((App)System.Windows.Application.Current).CurrentElements.MedicineSelected;
            if (MedicineForUpdate != null)
            {
                if (File.Exists(MedicineForUpdate.ProfileImagePath))
                {
                    string tempPath = System.IO.Path.GetTempFileName();
                    File.Copy(MedicineForUpdate.ProfileImagePath, tempPath, true);
                    ImageSrc = new BitmapImage(new Uri(tempPath));
                }
            }
            UpdateMedDetailes = new UpdateMedicineCommand(this);
            FileDialogCommand = new OpenFileDialogCommand(this);
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
        public string GenericName { get { return MedicineForUpdate.GenericName; } set { MedicineForUpdate.GenericName = value; _flag = true; } }
        public string ActiveIngredients { get { return MedicineForUpdate.ActiveIngredients; } set { MedicineForUpdate.ActiveIngredients = value; _flag = true; } }
        public string Manufacturer { get { return MedicineForUpdate.Manufacturer; } set { MedicineForUpdate.Manufacturer = value; _flag = true; } }

        Dictionary<string, string> validationErrors = new Dictionary<string, string>();
        void Validate()
        {
            validationErrors.Clear();
            if (string.IsNullOrWhiteSpace(GenericName))
            {
                validationErrors.Add("GenericName", "יש להזין שם גנרי");
            }
            if (string.IsNullOrWhiteSpace(ActiveIngredients))
            {
                validationErrors.Add("ActiveIngredients", "יש להזין נתונים");
            }
            if (string.IsNullOrWhiteSpace(Manufacturer))
            {
                validationErrors.Add("Manufacturer", "יש להזין נתונים");
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
                        case "GenericName":
                            if (string.IsNullOrWhiteSpace(GenericName))
                            {
                                errorMessage = "יש להזין שם גנרי";
                            }
                            break;
                        case "ActiveIngredients":
                            if (string.IsNullOrWhiteSpace(ActiveIngredients))
                                errorMessage = "יש להזין נתונים";
                            break;
                        case "Manufacturer":
                            if (string.IsNullOrWhiteSpace(Manufacturer))
                            {
                                errorMessage = "יש להזין נתונים";
                            }
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
                UpdateMedicine();
            }
        }
        public void UpdateMedicine()
        {
            try
            {
                _medicineAdminSide_M.UpdateMedicine(MedicineForUpdate);
                ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell =
    ((App)System.Windows.Application.Current).CurrentElements.StackOnShell.Peek();
            }
            catch(Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
