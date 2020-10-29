using System.ComponentModel;
using System.Windows.Input;
using BLL.BE;

namespace DrugSystem
{
    public class AddNewMedicineWindow_VM : INotifyPropertyChanged
    {
        public AddNewMedicinWindow_M AddNewMedicineWindow_M { get; set; }
        public Medicine newMedicine { get; set; }
        public ICommand CreateNewMedicineCommand { get; set; }
        public AddNewMedicineWindow_VM()
        {
           AddNewMedicineWindow_M = new AddNewMedicinWindow_M();
            CreateNewMedicineCommand = new CreateNewMedicineCommand(this);
            newMedicine = new Medicine();
        }
        public void CreateNewDoctor()
        {
            AddNewMedicineWindow_M.AddNewMedicine(newMedicine);
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
            MedicineCode = AddNewMedicineWindow_M.GetMedicineCode(MedicinesName);
            return MedicineCode != null;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}