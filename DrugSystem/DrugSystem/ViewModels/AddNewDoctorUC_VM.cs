﻿using System;
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
    public class AddNewDoctorUC_VM : INotifyPropertyChanged
    {
        AddNewDoctorUC_M _addNewDoctorUC_M;
        public Doctor newDoctor { get; set; }
        public ICommand CreateNewDoctorCommand { get; set; }
        public ICommand FileDialogCommand { get; set; }
        public List<Gender> Gender { get; set; }

        string _imgSrc;
        public string ImageSrc { get { return _imgSrc; } 
            set { _imgSrc = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImageSrc"));
            } 
        }
        public AddNewDoctorUC_VM()
        {           
            _addNewDoctorUC_M = new AddNewDoctorUC_M();
            Gender = _addNewDoctorUC_M.Gender;
            CreateNewDoctorCommand = new CreateNewDoctorCommand(this);
            FileDialogCommand = new OpenFileDialogCommand(this);
            newDoctor = new Doctor();
            ImageSrc = @"/Icons/UserIcon.jpg";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void CreateNewDoctor()
        {
            _addNewDoctorUC_M.AddNewDoctor(newDoctor);
        }
       
    }
}
