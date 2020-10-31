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
        public AddNewDoctorUC_VM()
        {           
            _addNewDoctorUC_M = new AddNewDoctorUC_M();
            Gender = _addNewDoctorUC_M.Gender;
            CreateNewDoctorCommand = new CreateNewDoctorCommand(this);
            FileDialogCommand = new OpenFileDialogCommand();
            newDoctor = new Doctor();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void CreateNewDoctor()
        {
            _addNewDoctorUC_M.AddNewDoctor(newDoctor);
        }
       
    }
}
