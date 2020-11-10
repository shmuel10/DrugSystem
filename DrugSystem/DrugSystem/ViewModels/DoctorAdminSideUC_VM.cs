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
    public class DoctorAdminSideUC_VM : INotifyPropertyChanged
    {
        DoctorAdminSideUC_M _doctorAdminSideUC_M;
        public ICommand FileDialogCommand { get; set; }
        public ICommand UpdateDoctorDetailes { get; set; }
        public List<Gender> Gender { get; set; }
        public Doctor DoctorForUpdate { get; set; }
        BitmapImage _imageSrc;
        public BitmapImage ImageSrc { get { return _imageSrc; } 
            set { _imageSrc = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImageSrc"));
            } 
        }
        public DoctorAdminSideUC_VM()
        {
            _doctorAdminSideUC_M = new DoctorAdminSideUC_M();
            DoctorForUpdate = ((App)System.Windows.Application.Current).CurrentElements.DoctorSelected;
            if (DoctorForUpdate != null)
            {
                if (File.Exists(DoctorForUpdate.ProfileImagePath))
                {
                    string tempPath = System.IO.Path.GetTempFileName();
                    File.Copy(DoctorForUpdate.ProfileImagePath, tempPath, true);
                    ImageSrc =  new BitmapImage(new Uri(tempPath));
                }
            }
            UpdateDoctorDetailes = new UpdateDoctorCommand(this);
            FileDialogCommand = new OpenFileDialogCommand(this);
            Gender = _doctorAdminSideUC_M.Gender;
        }
        private string _errorMessage = string.Empty;
        public string ErrorMessage {
            get { return _errorMessage; }
            set {
                _errorMessage = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ErrorMessage"));
            }
        }
        public void UpdateDoctor()
        {
            try
            {
                _doctorAdminSideUC_M.UpdateDoctor(DoctorForUpdate);
                ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell =
    ((App)System.Windows.Application.Current).CurrentElements.StackOnShell.Peek();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
