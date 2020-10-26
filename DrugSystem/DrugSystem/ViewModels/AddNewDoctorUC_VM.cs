using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using BLL.BE;
using DrugSystem.Command;
using DrugSystem.Models;
using static BLL.BE.AuxiliaryObjects;

namespace DrugSystem.ViewModels
{
    public class AddNewDoctorUC_VM : INotifyPropertyChanged
    {

        public DependencyProperty F { get; set; }

        public AddNewDoctorUC_M AddNewDoctorUC_M { get; set; }
        public Doctor newDoctor { get; set; }
        public ICommand CreateNewDoctorCommand { get; set; }
        public AddNewDoctorUC_VM(UserControl addNeWDocUC)
        {
            AddNewDoctorUC_M = new AddNewDoctorUC_M();      
            CreateNewDoctorCommand = new CreateNewDoctorCommand(this);
            newDoctor = new Doctor();
           
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void CreateNewDoctor()
        {
            AddNewDoctorUC_M.AddNewDoctor(newDoctor);
        }
    }
}
