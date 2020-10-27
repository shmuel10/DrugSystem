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
using DrugSystem.Views;

namespace DrugSystem.ViewModels
{
    public class AddNewDoctorUC_VM : INotifyPropertyChanged
    {
        public AddNewDoctorUC_M AddNewDoctorUC_M { get; set; }
        public Doctor newDoctor { get; set; }
        public ICommand CreateNewDoctorCommand { get; set; }
        public ICommand FileDialogCommand { get; set; }

        public AddNewDoctorUC_VM()
        {
            AddNewDoctorUC_M = new AddNewDoctorUC_M();
            CreateNewDoctorCommand = new CreateNewDoctorCommand(this);
            FileDialogCommand = new OpenFileDialogCommand();
            newDoctor = new Doctor();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void CreateNewDoctor()
        {
            //newDoctor.CanAddDoctor = CanAddDoctor;
            //newDoctor.CanAddMedicine = CanAddMedicine;
            //newDoctor.CanAddPatient = CanAddPatient;
            //newDoctor.CanCreatePrescriptions = CanCreatePrescriptions;
            AddNewDoctorUC_M.AddNewDoctor(newDoctor);
        }

        public bool CanAddDoctor { get { return newDoctor.CanAddDoctor; } set { newDoctor.CanAddDoctor = value; } }
        public bool CanAddMedicine { get { return newDoctor.CanAddMedicine; } set { newDoctor.CanAddMedicine = value; } }
        public bool CanAddPatient { get { return newDoctor.CanAddPatient; } set { newDoctor.CanAddPatient = value; } }
        public bool CanCreatePrescriptions { get { return newDoctor.CanCreatePrescriptions; } set { newDoctor.CanCreatePrescriptions = value; } }

    }
}
