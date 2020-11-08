using System;
using System.ComponentModel;
using System.Windows.Input;
using BLL.BE;
using DrugSystem.Command;
using DrugSystem.Models;

namespace DrugSystem.ViewModels
{
    public class AddNewMedicineUC_VM : INotifyPropertyChanged
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
        //private string _medicineCode;
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
        public bool MedicineExistInXML(string MedicinesName)
        {
            MedicineCode = _addNewMedicineWindow_M.GetMedicineCode(MedicinesName);
            return MedicineCode != null;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}