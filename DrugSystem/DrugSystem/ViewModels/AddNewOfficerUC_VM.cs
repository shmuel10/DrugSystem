using System.ComponentModel;
using System.Windows.Input;
using BLL.BE;
using DrugSystem.Command;

namespace DrugSystem.Views
{
    public class AddNewOfficerUC_VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public AddNewOfficerUC_M AddNewOfficerUC_M { get; set; }
        public Officer newOfficer { get; set; }
        public ICommand CreateNewOfficerCommand { get; set; }
        public ICommand FileDialogCommand { get; set; }

        public AddNewOfficerUC_VM()
        {
            AddNewOfficerUC_M = new AddNewOfficerUC_M();
            CreateNewOfficerCommand = new CreateNewOfficerCommand(this);
            FileDialogCommand = new OpenFileDialogCommand();
            newOfficer = new Officer();
        }
        public void CreateNewOfficer()
        {
            AddNewOfficerUC_M.AddNewOfficer(newOfficer);
        }

    }
}