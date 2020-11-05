using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using BLL.BE;
using DrugSystem.Command;
using DrugSystem.Models;
using static BLL.BE.AuxiliaryObjects;

namespace DrugSystem.ViewModels
{
    public class AddNewOfficerUC_VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        AddNewOfficerUC_M _addNewOfficerUC_M;
        public Officer newOfficer { get; set; }
        public ICommand CreateNewOfficerCommand { get; set; }
        public ICommand FileDialogCommand { get; set; }
        public List<Gender> Gender { get; set; }
        string _imgSrc;
        public string ImageSrc {
            get { return _imgSrc; }
            set {
                _imgSrc = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImageSrc"));
            }
        }
        public AddNewOfficerUC_VM()
        {
            _addNewOfficerUC_M = new AddNewOfficerUC_M();
            CreateNewOfficerCommand = new CreateNewOfficerCommand(this);
            FileDialogCommand = new OpenFileDialogCommand(this);
            Gender = _addNewOfficerUC_M.Gender;
            newOfficer = new Officer();
            ImageSrc = @"/Icons/UserIcon.jpg";
        }
        public void CreateNewOfficer()
        {
            _addNewOfficerUC_M.AddNewOfficer(newOfficer);
        }
    }
}