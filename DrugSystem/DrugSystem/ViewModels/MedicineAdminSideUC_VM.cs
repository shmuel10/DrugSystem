using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using BLL.BE;
using DrugSystem.Command;
using DrugSystem.Models;
using static BLL.BE.AuxiliaryObjects;

namespace DrugSystem.ViewModels
{
    public class MedicineAdminSideUC_VM : INotifyPropertyChanged
    {
        MedicineAdminSide_M _medicineAdminSide_M;
        public ICommand FileDialogCommand { get; set; }
        public ICommand UpdateMedDetailes { get; set; }
        public List<Gender> Gender { get; set; }
        public Medicine MedicineForUpdate { get; set; }
        BitmapImage _imageSrc;
        public BitmapImage ImageSrc {
            get { return _imageSrc; }
            set {
                _imageSrc = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImageSrc"));
            }
        }

        public MedicineAdminSideUC_VM()
        {
            _medicineAdminSide_M = new MedicineAdminSide_M();
            MedicineForUpdate = ((App)System.Windows.Application.Current).CurrentElements.MedicineSelected;
            if (MedicineForUpdate != null)
            {
                if (File.Exists(MedicineForUpdate.ProfileImagePath))
                {
                    string tempPath = System.IO.Path.GetTempFileName();
                    File.Copy(MedicineForUpdate.ProfileImagePath, tempPath, true);
                    ImageSrc = new BitmapImage(new Uri(tempPath));
                }
            }
            UpdateMedDetailes = new UpdateMedicineCommand(this);
            FileDialogCommand = new OpenFileDialogCommand(this);
        }
        public void UpdateMedicine()
        {
            _medicineAdminSide_M.UpdateMedicine(MedicineForUpdate);
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
