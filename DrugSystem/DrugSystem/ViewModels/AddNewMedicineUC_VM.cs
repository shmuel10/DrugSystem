using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using BLL.BE;
using DrugSystem.Command;
using DrugSystem.Models;

namespace DrugSystem.ViewModels
{
    public class AddNewMedicineUC_VM : INotifyPropertyChanged, IDataErrorInfo
    {
        AddNewMedicineUC_M _addNewMedicineWindow_M { get; set; }
        public Medicine newMedicine { get; set; }
        public ICommand CreateNewMedicineCommand { get; set; }
        public ICommand FileDialogCommand { get; set; }

        string _imgSrc;
        public string ImageSrc {
            get { return _imgSrc; }
            set {
                _imgSrc = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImageSrc"));
            }
        }
        public AddNewMedicineUC_VM()
        {
            _addNewMedicineWindow_M = new AddNewMedicineUC_M();
            CreateNewMedicineCommand = new CreateNewMedicineCommand(this);
            FileDialogCommand = new OpenFileDialogCommand(this);
            newMedicine = new Medicine();
            ImageSrc = @"/Icons/DefaultMedPicture.jpg";
        }

        public void CreateNewMedicine()
        {
            try
            {
                _addNewMedicineWindow_M.AddNewMedicine(newMedicine);
                ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell =
    ((App)System.Windows.Application.Current).CurrentElements.StackOnShell.Peek();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        public string MedicineCode {
            get { return newMedicine.MedicineID; }
            set {
                newMedicine.MedicineID = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MedicineCode"));
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
        public string GenericName { get { return newMedicine.GenericName; } set { newMedicine.GenericName = value; _flag = true; } }
        public string CommercialName { get { return newMedicine.CommercialName; } set { newMedicine.CommercialName = value; _flag = true; } }
        public string ActiveIngredients { get { return newMedicine.ActiveIngredients; } set { newMedicine.ActiveIngredients = value; _flag = true; } }
        public string Manufacturer { get { return newMedicine.Manufacturer; } set { newMedicine.Manufacturer = value; _flag = true; } }

        Dictionary<string, string> validationErrors = new Dictionary<string, string>();
        void Validate()
        {
            validationErrors.Clear();
            if (string.IsNullOrWhiteSpace(GenericName))
            {
                validationErrors.Add("GenericName", "יש להזין שם גנרי");
            }
            if (string.IsNullOrWhiteSpace(CommercialName))
                validationErrors.Add("CommercialName", "יש להזין שם מסחרי");
            else if (!MedicineExistInXML(CommercialName))
            {
                validationErrors.Add("CommercialName", "שם זה אינו קביל במערכת");
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
                        case "CommercialName":
                            if (string.IsNullOrWhiteSpace(CommercialName))
                                errorMessage = "יש להזין שם מסחרי";
                            else if (!MedicineExistInXML(CommercialName))
                                errorMessage = "שם זה אינו קביל במערכת";
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
                CreateNewMedicine();
            }
        }
        public bool MedicineExistInXML(string MedicinesName)
        {
            MedicineCode = _addNewMedicineWindow_M.GetMedicineCode(MedicinesName);
            return MedicineCode != null;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}