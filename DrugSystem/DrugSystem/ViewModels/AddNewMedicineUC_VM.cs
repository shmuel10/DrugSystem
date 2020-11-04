﻿using System.ComponentModel;
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
            _addNewMedicineWindow_M.AddNewMedicine(newMedicine);
        }
        //private string _medicineCode;
        public string MedicineCode {
            get { return newMedicine.MedicineID; }
            set {
                newMedicine.MedicineID = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MedicineCode"));
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