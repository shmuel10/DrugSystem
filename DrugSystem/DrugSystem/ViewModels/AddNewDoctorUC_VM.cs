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
        string _imgSrc;
        public string ImageSrc { get { return _imgSrc; } 
            set { _imgSrc = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImageSrc"));
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
            try
            {
                _addNewDoctorUC_M.AddNewDoctor(newDoctor);
                ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell =
    ((App)System.Windows.Application.Current).CurrentElements.StackOnShell.Peek();
            }
            catch(Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
