using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BLL.BE;
using DrugSystem.Command;
using DrugSystem.Models;

namespace DrugSystem.ViewModels
{
    public class AddNewDoctorUC_VM : INotifyPropertyChanged
    {
        AddNewDoctorUC_M AddNewDoctorUC_M;
        Doctor newDoctor;
        public ICommand CreateNewDoctorCommand { get; set; }
        public AddNewDoctorUC_VM(UserControl addNeWDocUC)
        {
            AddNewDoctorUC_M = new AddNewDoctorUC_M();
            newDoctor = new Doctor();
            CreateNewDoctorCommand = new CreateNewDoctorCommand(this);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void CreateNewDoctor()
        {
            AddNewDoctorUC_M.AddNewDoctor(newDoctor);
        }
    }
}
