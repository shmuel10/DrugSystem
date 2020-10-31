using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using BLL.BE;
using DrugSystem.Command;
using static BLL.BE.AuxiliaryObjects;

namespace DrugSystem.Views
{
    public class AddNewOfficerUC_VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        AddNewOfficerUC_M _addNewOfficerUC_M;
        public Officer newOfficer { get; set; }
        public ICommand CreateNewOfficerCommand { get; set; }
        public ICommand FileDialogCommand { get; set; }
        public List<Gender> Gender { get; set; }
        public AddNewOfficerUC_VM()
        {
            _addNewOfficerUC_M = new AddNewOfficerUC_M();
            CreateNewOfficerCommand = new CreateNewOfficerCommand(this);
            FileDialogCommand = new OpenFileDialogCommand();
            Gender = _addNewOfficerUC_M.Gender;
            newOfficer = new Officer();
        }
        public void CreateNewOfficer()
        {
            _addNewOfficerUC_M.AddNewOfficer(newOfficer);
        }

    }
}