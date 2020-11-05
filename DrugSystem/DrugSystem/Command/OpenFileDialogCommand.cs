using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using DrugSystem.ViewModels;
using Microsoft.Win32;

namespace DrugSystem.Command
{
    public class OpenFileDialogCommand : ICommand
    {
        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public INotifyPropertyChanged CurrentVM { get; set; }
        public OpenFileDialogCommand(INotifyPropertyChanged currentVM)
        {
            CurrentVM = currentVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "בחר תמונה";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                if (CurrentVM is AddNewDoctorUC_VM)
                {
                    string doctorID = ((AddNewDoctorUC_VM)CurrentVM).newDoctor.ID;
                    string picturePath = @"..\..\ProfilePictures" + @"\" + doctorID + @".JPG";
                    ((AddNewDoctorUC_VM)CurrentVM).newDoctor.ProfileImagePath = picturePath;
                    ((AddNewDoctorUC_VM)CurrentVM).newDoctor.ProfileImageSrc = op.FileName;
                    ((AddNewDoctorUC_VM)CurrentVM).ImageSrc = op.FileName;
                }
                else if (CurrentVM is DoctorAdminSideUC_VM)
                {
                    string doctorID = ((DoctorAdminSideUC_VM)CurrentVM).DoctorForUpdate.ID;
                    string picturePath = @"..\..\ProfilePictures" + @"\" + doctorID + @".JPG";
                    ((DoctorAdminSideUC_VM)CurrentVM).DoctorForUpdate.ProfileImagePath = picturePath;
                    ((DoctorAdminSideUC_VM)CurrentVM).DoctorForUpdate.ProfileImageSrc = op.FileName;
                    ((DoctorAdminSideUC_VM)CurrentVM).ImageSrc = new BitmapImage(new Uri(op.FileName));
                }
                else if (CurrentVM is AddNewMedicineUC_VM)
                {
                    string medID = ((AddNewMedicineUC_VM)CurrentVM).newMedicine.MedicineID;
                    string picturePath = @"..\..\ProfilePictures" + @"\" + medID + @".JPG";
                    ((AddNewMedicineUC_VM)CurrentVM).newMedicine.ProfileImagePath = picturePath;
                    ((AddNewMedicineUC_VM)CurrentVM).newMedicine.ProfileImageSrc = op.FileName;
                    ((AddNewMedicineUC_VM)CurrentVM).ImageSrc = op.FileName;
                }else if(CurrentVM is MedicineAdminSideUC_VM)
                {
                    string medID = ((MedicineAdminSideUC_VM)CurrentVM).MedicineForUpdate.MedicineID;
                    string picturePath = @"..\..\ProfilePictures" + @"\" + medID + @".JPG";
                    ((MedicineAdminSideUC_VM)CurrentVM).MedicineForUpdate.ProfileImagePath = picturePath;
                    ((MedicineAdminSideUC_VM)CurrentVM).MedicineForUpdate.ProfileImageSrc = op.FileName;
                    ((MedicineAdminSideUC_VM)CurrentVM).ImageSrc = new BitmapImage(new Uri(op.FileName));
                }else if(CurrentVM is AddNewOfficerUC_VM)
                {
                    string officerID = ((AddNewOfficerUC_VM)CurrentVM).newOfficer.ID;
                    string picturePath = @"..\..\ProfilePictures" + @"\" + officerID + @".JPG";
                    ((AddNewOfficerUC_VM)CurrentVM).newOfficer.ProfileImagePath = picturePath;
                    ((AddNewOfficerUC_VM)CurrentVM).newOfficer.ProfileImageSrc = op.FileName;
                    ((AddNewOfficerUC_VM)CurrentVM).ImageSrc = op.FileName;
                }else if(CurrentVM is OfficerAdminSideUC_VM)
                {
                    string officerID = ((OfficerAdminSideUC_VM)CurrentVM).OfficerForUpdate.ID;
                    string picturePath = @"..\..\ProfilePictures" + @"\" + officerID + @".JPG";
                    ((OfficerAdminSideUC_VM)CurrentVM).OfficerForUpdate.ProfileImagePath = picturePath;
                    ((OfficerAdminSideUC_VM)CurrentVM).OfficerForUpdate.ProfileImageSrc = op.FileName;
                    ((OfficerAdminSideUC_VM)CurrentVM).ImageSrc = new BitmapImage(new Uri(op.FileName));
                }
            }
        }
    }
}
